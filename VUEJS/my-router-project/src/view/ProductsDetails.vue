<template>
  <div class="row breadcrumb-shop">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pd5">
      <ol class="breadcrumb breadcrumb-arrows">
        <li><router-link to="/">Trang chủ</router-link></li>
        <li>
          <router-link
            :to="{
              name: 'ListProducts',
              params: { id: productCt.productCategorieId },
            }"
            >{{ productCt.name }}</router-link
          >
        </li>
        <li class="active">
          <span v-if="product != null"> {{ product.name }}</span>
        </li>
      </ol>
    </div>
  </div>

  <product :id="$route.params.id"></product>
  <h3 class="text-center mt-3">Sản phẩm cùng danh mục</h3>
  <list-products :products="ll"></list-products>
</template>
<script>
import HomeService from "../service/Home";
// Import Swiper Vue.js components
import Product from "../components/Product.vue";
import ListProducts from "../components/ListProducts.vue";
import Products from "../service/Products";
import { useRoute } from "vue-router";

export default {
  components: {
    ListProducts,
    Product,
  },
  data() {
    return {
      product: [],
      ll: null,
      productCt: [],
    };
  },
  homeService: null,
  productService: null,
  async created() {
    this.productService = new Products();
    this.homeService = new HomeService();
    const route = useRoute();

    await this.productService.getProductsId(route.params.id).then((data) => {
      this.product = data.product;
    });
    this.productService
      .getProductsCategory(this.product.productCategorieId)
      .then((data) => {
        this.productCt = data;
      });
    this.productService
      .getPcandPD(this.product.productCategorieId)
      .then((data) => {
        this.ll = data.selectParents;
      });
  },
  mounted() {},
  methods: {},
};
</script>


<style scoped>
.swiper-container {
  width: 100%;
  height: 100%;
}

.swiper-slide {
  text-align: center;
  font-size: 18px;
  background: #fff;

  /* Center slide text vertically */
  display: -webkit-box;
  display: -ms-flexbox;
  display: -webkit-flex;
  display: flex;
  -webkit-box-pack: center;
  -ms-flex-pack: center;
  -webkit-justify-content: center;
  justify-content: center;
  -webkit-box-align: center;
  -ms-flex-align: center;
  -webkit-align-items: center;
  align-items: center;
}

.swiper-slide img {
  display: block;
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.swiper-container {
  margin-left: auto;
  margin-right: auto;
}
.breadcrumb-shop {
  background: #f5f5f5;
}
.breadcrumb-shop .breadcrumb-arrows {
  padding: 10px 0;
  background: transparent;
  border-radius: 0;
  margin: 0;
}
.breadcrumb-shop .breadcrumb > li + li:before {
  padding: 0 3px;
}
.breadcrumb-shop .breadcrumb-arrows li {
  font-size: 13px;
}
.breadcrumb > li + li:before {
  padding: 0 5px;
  color: #ccc;
  content: "/\00a0";
}
a {
  transition: opacity 150ms linear, color 150ms linear, background 150ms linear;
}
a {
  color: #000000;
  text-decoration: none;
  outline: none;
  -moz-transition: all 0.2s ease-in-out;
  -o-transition: all 0.2s ease-in-out;
  -webkit-transition: all 0.2s ease-in-out;
  transition: all 0.2s ease-in-out;
}
</style>