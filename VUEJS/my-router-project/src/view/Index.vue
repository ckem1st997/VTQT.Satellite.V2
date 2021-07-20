<template>
  <!-- <div class="d-flex"></div> -->
  <!-- 
  <div class="svgContainer" id="svgContainer"></div>
  <div class="svgContainer" id="svgContainer1"></div> -->
  <!-- slide -->
  <div
    id="carouselExampleIndicators"
    class="carousel slide"
    data-bs-ride="carousel"
  >
    <div class="carousel-indicators">
      <button
        type="button"
        data-bs-target="#carouselExampleIndicators"
        data-bs-slide-to="0"
        class="active"
        aria-current="true"
        aria-label="Slide 1"
      ></button>
      <button
        type="button"
        data-bs-target="#carouselExampleIndicators"
        data-bs-slide-to="1"
        aria-label="Slide 2"
      ></button>
      <button
        type="button"
        data-bs-target="#carouselExampleIndicators"
        data-bs-slide-to="2"
        aria-label="Slide 3"
      ></button>
    </div>
    <div class="carousel-inner">
      <div class="carousel-item active">
        <img
          class="d-block w-100"
          v-lazy="{
            src: 'https://mdbootstrap.com/img/Photos/Slides/img%20(9).jpg',
            loading: srcload,
            error: srcerror,
          }"
        />
      </div>
      <div class="carousel-item">
        <img
          class="d-block w-100"
          v-lazy="{
            src: 'https://mdbootstrap.com/img/Photos/Slides/img%20(68).jpg',
            loading: srcload,
            error: srcerror,
          }"
        />
      </div>
      <div class="carousel-item">
        <img
          class="d-block w-100"
          v-lazy="{
            src: 'https://mdbootstrap.com/img/Photos/Slides/img%20(6).jpg',
            loading: srcload,
            error: srcerror,
          }"
        />
      </div>
    </div>
    <button
      class="carousel-control-prev"
      type="button"
      data-bs-target="#carouselExampleIndicators"
      data-bs-slide="prev"
    >
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Previous</span>
    </button>
    <button
      class="carousel-control-next"
      type="button"
      data-bs-target="#carouselExampleIndicators"
      data-bs-slide="next"
    >
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Next</span>
    </button>
  </div>

  <!-- show -->
  <div class="title-home text-center mt-5">
    <h3>Danh mục hot</h3>
  </div>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-3 col-6 mb-4">
        <router-link :to="{ name: 'Product', params: { id: 1 } }">
          <div class="card">
            <img
              src="https://mdbootstrap.com/img/Photos/Horizontal/E-commerce/Vertical/5.jpg"
              class="card-img-top"
              alt="..."
            />

            <div class="stripe dark">
              <p class="card-title">
                Quần <i class="fas fa-chevron-right"></i>
              </p>
            </div>
          </div>
        </router-link>
      </div>

      <div class="col-md-3 col-6 mb-4">
        <router-link :to="{ name: 'Product', params: { id: 1 } }">
          <div class="card">
            <img
              src="https://mdbootstrap.com/img/Photos/Horizontal/E-commerce/Vertical/8.jpg"
              class="card-img-top"
              alt="..."
            />
            <div class="stripe light">
              <p class="card-title">Áo <i class="fas fa-chevron-right"></i></p>
            </div>
          </div>
        </router-link>
      </div>

      <div class="col-md-3 col-6 mb-4">
        <router-link :to="{ name: 'Product', params: { id: 1 } }">
          <div class="card">
            <img
              src="https://mdbootstrap.com/img/Photos/Horizontal/E-commerce/Vertical/9.jpg"
              class="card-img-top"
              alt="..."
            />
            <div class="stripe dark">
              <p class="card-title">
                Áo thun <i class="fas fa-chevron-right"></i>
              </p>
            </div>
          </div>
        </router-link>
      </div>

      <div class="col-md-3 col-6 mb-4">
        <router-link :to="{ name: 'Product', params: { id: 1 } }">
          <div class="card">
            <img
              src="https://mdbootstrap.com/img/Photos/Horizontal/E-commerce/Vertical/7.jpg"
              class="card-img-top"
              alt="..."
            />
            <div class="stripe light">
              <p class="card-title">
                Áo sơ mi <i class="fas fa-chevron-right"></i>
              </p>
            </div>
          </div>
        </router-link>
      </div>
    </div>
    <hr class="mt-2 mb-5" />
  </div>

  <!-- chi tiết -->
  <section class="container-fluid">
    <div class="row">
      <div class="col-sm-4 text-center mt-1">
        <i class="fa-chart-area red-text fa-3x fas"></i>
        <h5 class="font-weight-bold mt-3">Analytics</h5>
        <p class="grey-text">Giao hàng nhanh chóng</p>
      </div>
      <div class="col-sm-4 text-center mt-1">
        <i class="fa-book cyan-text fa-3x fas"></i>
        <h5 class="font-weight-bold mt-3">Tutorials</h5>
        <p class="grey-text">Đầy đủ hướng dẫn chi tiết</p>
      </div>
      <div class="col-sm-4 text-center mt-1">
        <i class="fa-comments orange-text fa-3x far"></i>
        <h5 class="font-weight-bold mt-3">Support</h5>
        <p class="grey-text">Hỗ trợ lâu dài nha</p>
      </div>
    </div>
    <hr class="mt-5" />
  </section>

  <!-- list product -->
  <h3 class="text-center mt-2 mb-3">DANH SÁCH SẢN PHẨM</h3>
  <list-products :products="products"></list-products>

  <!-- list bai viet -->
  <h3 class="text-center mt-2 mb-3">BÀI VIẾT</h3>
  <list-category :article="article"></list-category>
</template>

<script>
import ListProducts from "../components/ListProducts.vue";
import ListCategory from "../components/ListCategory.vue";
import HomeService from "../service/Home";
import srcld from "../assets/ld.gif";
import srcer from "../assets/er.jpg";
export default {
  components: {
    ListProducts,
    ListCategory,
  },
  data() {
    return {
      products: [],
      article: [],
      srcerror: srcer,
      srcload: srcld,
    };
  },
  // productService: null,
  homeService: null,
  async created() {
    this.homeService = new HomeService();
    await this.homeService.getListProducts().then((data) => {
      this.products = data;
    });

    await this.homeService.getListArticle().then((data) => {
      this.article = data;
    });
  },
  mounted() {},
  methods: {
    getImage(img) {
      return img.split(",")[1];
    },
    CeilPrice(a, b) {
      return Math.ceil((a / b) * 100);
    },
  },
};
</script>
<style scoped>
.my-card {
  display: flex;
  -ms-flex-direction: column;
  flex-direction: column;
  min-width: 0;
  background-color: #fff;
  background-clip: border-box;
  box-shadow: 0px 0px 5px;
  margin-bottom: 28px;
  border-radius: 10px;
  overflow: hidden;
  transition: 0.5s;
}

.my-card:hover {
  box-shadow: 0px 0px 8px #c81a3b;
}

.my-card img {
  max-height: 250px;
  width: 100%;
}

.my-card-body {
  padding: 15px;
  /*  margin-bottom: 10px; */
}
.card-new {
  position: absolute;
  top: 10px;
  left: 10px;
}
.card-sale {
  position: absolute;
  top: 10px;
  right: 10px;
}
.deep-orange-text {
  color: #ff5722 !important;
}
.my-card-body h5 {
  text-transform: capitalize;
  line-height: 25px;
  font-size: 25px;
}

.my-card-body p {
  margin: 10px 0;
  color: #f7941d;
}

.social-icons {
  margin-bottom: 15px;
}

.social-icons a {
  margin-right: 22px;
  color: #363842;
  font-size: 16px;
}

.social-icons a:hover {
  color: #c81a3b;
}

.my-card-btn {
  color: rgb(231, 231, 231);
  background-color: #c81a3b;
  padding: 10px 28px;
  text-decoration: none;
  text-transform: capitalize;
  border-radius: 10px 0;
  transition: 0.5s;
}

.my-card-btn:hover {
  color: rgb(15, 15, 15);
  background: rgb(171, 241, 6);
}
.my-card a {
  text-decoration: none;
}

.svgContainer {
  max-width: 20%;
  max-height: 20%;
  background-color: #1e1c26;
  /* position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  margin: auto; */
  margin-bottom: 20px;
}

.stripe.dark {
  background-color: rgba(0, 0, 0, 0.7);
}

.stripe.light {
  background-color: hsla(0, 0%, 100%, 0.7);
}
.stripe {
  position: absolute;
  bottom: 3rem;
  width: 100%;
  padding: 1rem;
  text-align: center;
  color: #eee;
}
.stripe.light p {
  color: #424242;
}
.red-text {
  color: #f44336 !important;
}
.grey-text {
  color: #9e9e9e !important;
}
.cyan-text {
  color: #00bcd4 !important;
}
.orange-text {
  color: #ff9800 !important;
}
@media screen and (max-width: 768px) {
  .name-products {
    font-size: 11px;
  }
  .price-products {
    font-size: 12px;
  }
}
@media screen and (min-width: 992px) {
  .price-products {
    font-size: 12px;
  }
}
@media screen and (min-width: 1200px) {
  .price-products {
    font-size: 16px;
  }
}
img {
  max-width: 100%;
}
.my-card-img {
  transition: all 0.2s linear;
}
.dark-grey-text,
.dark-grey-text:focus,
.dark-grey-text:hover {
  color: #4f4f4f !important;
}
.my-card-img:hover {
  transform: scale(1.05);
}
a {
  text-decoration: none;
}
</style>

    








