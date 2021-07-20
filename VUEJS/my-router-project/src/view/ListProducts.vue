<template>
  <div class="row breadcrumb-shop">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pd5">
      <ol class="breadcrumb breadcrumb-arrows">
        <li><router-link to="/">Trang chủ</router-link></li>

        <li class="active">
          <span>{{ pct.name }} </span>
        </li>
      </ol>
    </div>
  </div>

  <section class="show-image container-fluid mt-3">
    <img
      class="my-card-img"
      :src="
        'http://res.cloudinary.com/imageshared/image/upload/c_scale,f_auto,q_auto/v1/' +
        pct.coverImage
      "
    />
  </section>

  <h3 class="text-center mt-3">DANH SÁCH SẢN PHẨM</h3>

  <section class="container-fluid listproducts">
    <div class="row locproducts">
      <div class="option-list col-12 col-md-3">
        <p class="title-filters">Filters</p>
        <hr />
        <div class="row">
          <div class="col-6 col-md-12 title-list-products">
            <p class="title-condition">Review</p>
            <div class="check-list" style="color: #e3c700">
              <mdb-icon far="" icon="star" class="far">
                <i class="fa-star far"></i
              ></mdb-icon>
              <mdb-icon far="" icon="star" class="far">
                <i class="fa-star far"></i></mdb-icon
              ><mdb-icon fas="" icon="star" class="fas"
                ><i class="fa-star fas"></i></mdb-icon
              ><mdb-icon far="" icon="star" class="far"
                ><i class="fa-star far"></i></mdb-icon
              ><mdb-icon far="" icon="star" class="far"
                ><i class="fa-star far"></i
              ></mdb-icon>
            </div>
          </div>
          <div class="col-6 col-md-12 title-list-products">
            <p class="title-price">Price</p>
            <div class="check-list-price">
              <div class="mt-5">
                <Slider v-model="value" :max="1000000" />
              </div>
            </div>
          </div>
          <div class="col-6 col-md-12 title-list-products">
            <p class="title-size">Size</p>
            <div class="check-list-size d-flex flex-wrap">
              <div
                v-for="item in listsize"
                class="form-check col-md-6 col-lg-4 col-6"
                :key="item"
              >
                <input
                  type="radio"
                  id="materialUnchecked"
                  name="materialExampleRadios"
                  mdbinput=""
                  class="form-check-input onFocusSelect"
                  :value="item.sizeProduct"
                  v-on:click="checksize"
                /><label
                  for="materialUnchecked"
                  class="form-check-label active"
                  :value="item.sizeProduct"
                  >{{ item.sizeProduct }}</label
                >
              </div>

              <!---->
            </div>
          </div>
          <div class="col-6 col-md-12 title-list-products">
            <p class="title-color">Color</p>
            <div class="layered-content filter-color s-filter">
              <ul class="check-box-list">
                <li v-for="item in listcl" :key="item">
                  <input
                    type="radio"
                    name="color-filter"
                    :id="item.colorId"
                    :value="item.nameColor"
                  /><label
                    :for="item.colorId"
                    :value="item.nameColor"
                    :style="{ backgroundColor: item.code }"
                    v-on:click="checkcolor"
                  ></label>
                </li>

                <!---->
              </ul>
            </div>
          </div>
        </div>
        <div class="text-center mt-2">
          <button
            type="button"
            mdbbtn=""
            color="primary"
            size="sm"
            class="ml-0 btn-primary btn-sm btn"
            v-on:click="Search()"
          >
            Tìm kiếm
          </button>
        </div>
        <hr />
      </div>
      <div class="show-list col-12 col-md-9">
        <div class="select-list d-flex justify-content-between">
          <div class="select-list--1">
            <select
              class="browser-default custom-select"
              v-on:change="selectList"
            >
              <option selected="" value="0">Mới nhất</option>
              <option value="1">Giá: Tăng dần</option>
              <option value="2">Giá: Giảm dần</option>
              <option value="3">Tên: A-Z</option>
              <option value="4">Tên: Z-A</option>
            </select>
          </div>
          <div class="select-list--2 d-flex justify-content-center">
            <nav aria-label="Page navigation example">
              <ul class="pagination pagination-circle pg-blue">
                <li class="page-item" v-on:click="blackpage">
                  <a aria-label="Previous" class="page-link"
                    ><span aria-hidden="true">«</span
                    ><span class="sr-only">Previous</span></a
                  >
                </li>
                <li
                  v-for="item in arrypage"
                  :key="item"
                  v-on:click="checkNumber"
                  v-bind:class="{ active: item == number }"
                  class="numberli page-item"
                >
                  <a class="page-link"> {{ item }} </a>
                </li>
                <!---->
                <li class="page-item" v-on:click="nextpage">
                  <a aria-label="Next" class="page-link"
                    ><span aria-hidden="true">»</span
                    ><span class="sr-only">Next</span></a
                  >
                </li>
              </ul>
            </nav>
          </div>
        </div>
        <list-products :products="products"></list-products>
      </div>
    </div>
  </section>
</template>
<script>
import srcld from "../assets/ld.gif";
import srcer from "../assets/er.jpg";
import HomeService from "../service/Home";
import ProductService from "../service/Products";
import { useRoute } from "vue-router";
import ListProducts from "../components/ListProducts.vue";
import Slider from "@vueform/slider";
export default {
  components: {
    ListProducts,
    Slider,
  },
  data: () => ({
    value: [1000, 1000000],
    products: [],
    pct: [],
    srcerror: srcer,
    srcload: srcld,
    color: "",
    size: "",
    listcl: [],
    listsize: [],
    type: 0,
    number: 1,
    arrypage: [1, 2, 3, 4, 5],
    coutpage: 5,
    numberlist: 1,
  }),
  homeService: null,
  productService: null,
  async created() {
    this.productService = new ProductService();
    this.homeService = new HomeService();
    const route = useRoute();
    await this.productService
      .getProductsCategory(route.params.id)
      .then((data) => {
        this.pct = data;
        this.products = this.Search();
      });
    await this.productService.getSC().then((data) => {
      this.listcl = data.colors;
      this.listsize = data.sizes;
    });
  },
  mounted() {},
  methods: {
    nextpage(event) {
      console.log(this.number);
      this.number = this.number + 1;
      console.log(this.number);
      this.Search();
    },
    blackpage(event) {
      if (this.number > 1) this.number = this.number - 1;
      this.Search();
    },

    selectList(event) {
      this.type = event.target.value;
      this.Search();
    },
    checkNumber(event) {
      for (
        let index = 0;
        index < document.getElementsByClassName("numberli").length;
        index++
      ) {
        const element = document.getElementsByClassName("numberli")[index];
        element.className = element.className.replace(" active", "");
      }
      event.target.parentNode.className =
        event.target.parentNode.className + " active";
      this.number = parseInt(event.target.innerHTML.trim());
      this.productService
        .getPhanTrang(
          this.pct.productCategorieId,
          this.value[0],
          this.value[1],
          this.size,
          this.color,
          this.type,
          this.number
        )
        .then((data) => {
          this.products = data.selectParents;
        });
    },
    checkcolor(event) {
      this.color = event.target.getAttribute("value");
    },
    checksize(event) {
      this.size = event.target.value;
    },
    Search() {
      this.productService
        .getPhanTrang(
          this.pct.productCategorieId,
          this.value[0],
          this.value[1],
          this.size,
          this.color,
          this.type,
          this.number
        )
        .then((data) => {
          this.products = data.selectParents;

          this.number = data.numberpage;
          this.coutpage = data.countpage;

          if (this.number <= 5) this.numberlist = 0;
          else if (this.numberpage % 5 != 0)
            this.numberlist = Math.floor(this.number / 5) + 1;
          else this.numberlist = this.number / 5;
          if (this.numberlist * 5 >= this.coutpage || this.coutpage < 5)
            this.numberlist = this.coutpage;
          else this.numberlist = 5 * this.numberlist;
          if (this.numberlist > 0) {
            this.arrypage = [];

            for (
              let index = this.numberlist - 4 > 0 ? this.numberlist - 4 : 1;
              index <= this.numberlist;
              index++
            ) {
              this.arrypage.push(index);
            }
          } else this.arrypage = [1, 2, 3, 4, 5];
        });
    },
  },
};
</script>
<style src="@vueform/slider/themes/default.css"></style>
<style scoped>
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
img {
  max-width: 100%;
}

.content-filter .option {
  margin-top: 30px;
}
.option .lb-filter {
  display: block;
  font-size: 15px;
  opacity: 0.92;
  margin-bottom: 0px;
}
.custom-dropdown {
  display: inline-block;
  position: relative;
  vertical-align: middle;
  max-width: 100%;
  overflow: hidden;
  border-radius: 0px;
}
.custom-dropdown::after {
  content: "\f078";
  font-family: FontAwesome;
  font-size: 13px;
  color: #252a2b;
  opacity: 0.42;
  display: block;
  position: absolute;
  top: 10px;
  right: 17px;
}
.option .custom-dropdown .custom-dropdown__select {
  font-size: 14px;
  width: 100%;
  display: block;
  height: 30px;
  padding: 0 20px 0 0;
  border-color: transparent;
  border-bottom: 1px solid #000;
  background-color: #fff;
  outline: 0;
  -moz-border-radius: 0;
  -webkit-border-radius: 0;
  border-radius: 0;
  -moz-appearance: none;
  -webkit-appearance: none;
  cursor: pointer;
  text-indent: 1px;
}
.option .custom-dropdown {
  width: 100%;
}
.option .custom-dropdown::after {
  content: "\f103";
  font-family: FontAwesome;
  font-size: 14px;
  color: #000;
  display: block;
  position: absolute;
  top: 9px;
  right: 2px;
}
.option .option-children:not(:first-child) {
  margin-bottom: 30px;
}
.option select option {
  background: #fff;
}
.option.browse-tags .lb-filter {
  display: inline-block;
}
.option.browse-tags .custom-dropdown {
  width: auto;
  float: right;
}

.left-module {
  margin-bottom: 20px;
  overflow: hidden;
}
.block .title_block {
  display: block;
  font-size: 14px;
  margin: 0 0 5px;
  font-weight: 700;
  text-transform: uppercase;
  background: #f5f5f5;
  padding: 8px 15px;
}
.layered .layered_subtitle {
  text-transform: uppercase;
  font-size: 14px;
  line-height: 22px;
  padding: 10px 0 10px;
  cursor: pointer;
  position: relative;
}
.layered .layered_subtitle span {
  font-weight: 600;
  font-size: 13px;
}
.layered span.icon-control {
  position: relative;
  top: -2px;
  left: 5px;
  font-size: 8px;
}
.group-filter[aria-expanded="false"] .dropdown-filter .icon-control i:before {
  content: "\f067";
}
.group-filter[aria-expanded="false"] .layered-content {
  display: none;
  height: 0;
}
.group-filter[aria-expanded="true"] .layered-content {
  height: auto;
}
.group-filter .layered-content {
  -webkit-transition: all 0.2s;
  transition: all 0.2s;
}
.check-box-list {
  margin: 0 0 10px;
}
.check-box-list li {
  line-height: 20px;
  font-size: 12px;
}
.check-box-list label {
  display: inline-block;
  cursor: pointer;
  line-height: 18px;
  font-weight: normal;
  margin-bottom: 0;
  color: #252a2b;
}
.check-box-list li:hover label {
  color: #e00000;
}
.check-box-list input[type="radio"] {
  display: none;
}
.filter-price li {
  font-size: 14px;
  margin-bottom: 5px;
}
.filter-price li:last-child {
  margin-bottom: 0;
}
.filter-price li span {
  font-size: 12px;
}
.filter-color ul {
  padding: 0;
  margin: 0;
  overflow: hidden;
}
.filter-color li {
  display: inline;
  margin: 0 10px 10px 0;
  line-height: normal;
  float: left;
}
.filter-color li label {
  border: 1px solid #eaeaea;
  width: 25px;
  height: 25px;
  float: left;
  position: relative;
  background-size: contain;
  border-radius: 50%;
}
.filter-color li input[type="radio"]:checked + label:before {
  position: absolute;
  -webkit-transform: rotate(-45deg);
  transform: rotate(-45deg);
  content: "";
  border-width: 0 0 2px 2px !important;
  height: 5px;
  width: 9px;
  z-index: 99;
  border: solid rgb(121, 118, 118);
  margin: 7px 0 0 7px;
}
.filter-size li {
  text-align: center;
  margin-right: -1px;
  margin-bottom: -1px;
  float: left;
}
.filter-size li label {
  width: 42px;
  height: 42px;
  line-height: 42px;
  position: relative;
  border: 1px solid #e5e5e5;
}
.filter-size li input[type="checkbox"]:checked + label,
.size-filter li:hover label {
  background-color: #111;
  color: #fff;
  border: 1px solid #111;
}
.block .block_content {
  overflow-y: auto;
  overflow-x: hidden;
}
.bl-filter [type="checkbox"]:not(:checked),
.bl-filter [type="checkbox"]:checked {
  position: absolute;
  left: -9999px;
}
.bl-filter [type="checkbox"]:not(:checked) + label,
.bl-filter [type="checkbox"]:checked + label {
  position: relative;
  padding-left: 22px;
  cursor: pointer;
}
.bl-filter [type="checkbox"]:not(:checked) + label:before,
.bl-filter [type="checkbox"]:checked + label:before {
  content: "";
  position: absolute;
  left: 0;
  top: 2px;
  width: 14px;
  height: 14px;
  border: 1px solid #e5e5e5;
  background: #fff;
  border-radius: 2px;
}
.bl-filter [type="checkbox"]:checked + label:before {
  border: 1px solid #000;
}
.bl-filter [type="checkbox"]:not(:checked) + label:after,
.bl-filter [type="checkbox"]:checked + label:after {
  position: absolute;
  -webkit-transform: rotate(-45deg);
  transform: rotate(-45deg);
  content: "";
  border-width: 0 0 2px 2px !important;
  height: 4px;
  width: 7px;
  border: solid #111;
  margin: 9px 0 0 4px;
  left: 0;
  top: -3px;
  transition: all 0.2s;
}
.bl-filter [type="checkbox"]:not(:checked) + label:after {
  opacity: 0;
}
.bl-filter [type="checkbox"]:checked + label:after {
  opacity: 1;
}
.bl-filter label:hover:before {
  border: 1px solid #000 !important;
}

.list-products .banner-list-image {
  margin-top: -16px;
}
.list-products .listproducts .locproducts .title-list-products {
  margin-top: 15px;
}
.list-products
  .listproducts
  .locproducts
  .option-list
  .check-list-color
  button {
  border-radius: 50%;
}
@media screen and (min-width: 656px) {
  .list-products .listproducts .locproducts .show-list .select-list {
    display: flex;
    justify-content: space-between;
  }
}
.list-products
  .listproducts
  .locproducts
  .show-list
  .select-list
  .select-list--1 {
  margin-bottom: 15px;
}
@media screen and (max-width: 506px) {
  .price-products {
    font-size: 12px;
  }
}

body {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  background: #f1f1f1;
}

h3 {
  margin-top: 0;
}

.example {
  background: #ffffff;
  margin: 20px;
  border-color: #e7e7e7;
  padding: 40px;
}

.example pre {
  background: #f9f9f9;
  padding: 18px 6px;
  overflow-x: scroll;
  margin-top: 10px;
}

.output {
  font-family: Courier, Courier New, Lucida Console, Monaco, Consolas;
  background: #000000;
  color: #ffffff;
  padding: 20px;
  margin-bottom: 50px;
  display: inline-block;
  width: 100%;
  box-sizing: border-box;
  font-size: 13px;
}

.slider-vertical {
  margin: -30px auto 0;
}

.pagination.pg-blue .page-item.active .page-link,
.pagination.pg-blue .page-item.active .page-link:hover {
  background-color: #4285f4;
}

.pagination.pagination-circle .page-item.active .page-link,
.pagination.pagination-circle .page-item .page-link:hover {
  border-radius: 50%;
}
.pagination.pagination-circle .page-item .page-link {
  margin-left: 2px;
  margin-right: 2px;
  border-radius: 50%;
}
.pagination .page-item.active .page-link {
  box-shadow: 0 2px 5px 0 rgb(0 0 0 / 16%), 0 2px 10px 0 rgb(0 0 0 / 12%);
  transition: all 0.2s linear;
  border-radius: 0.125rem;
  background-color: #4285f4;
  color: #fff;
}
.pagination .page-item .page-link {
  transition: all 0.3s linear;
  outline: 0;
  border: 0;
  background-color: initial;
  font-size: 0.9rem;
  color: #212529;
}
.page-item.active .page-link {
  z-index: 3;
  color: #fff;
  background-color: #007bff;
  border-color: #007bff;
}
a:not([href]):not([tabindex]),
a:not([href]):not([tabindex]):focus,
a:not([href]):not([tabindex]):hover {
  color: inherit;
  text-decoration: none;
}
a:not([href]),
a:not([href]):hover {
  color: inherit;
  text-decoration: none;
}
.page-link {
  position: relative;
  display: block;
  padding: 0.5rem 0.75rem;
  margin-left: -1px;
  line-height: 1.25;
  color: #007bff;
  background-color: #fff;
  border: 1px solid #dee2e6;
}

.custom-select {
  display: inline-block;
  width: 100%;
  height: calc(1.5em + 0.75rem + 2px);
  padding: 0.375rem 1.75rem 0.375rem 0.75rem;
  font-size: 1rem;
  font-weight: 400;
  line-height: 1.5;
  color: #495057;
  vertical-align: middle;
  border: 1px solid #ced4da;
}
</style>
