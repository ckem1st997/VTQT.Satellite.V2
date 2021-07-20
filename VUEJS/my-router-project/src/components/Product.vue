<template>
  <div class="container-fluid mt-3">
    <div class="row">
      <div class="col-12 col-md-7">
        <div class="w-100">
          <swiper
            :slidesPerView="1"
            :spaceBetween="30"
            :loop="true"
            :pagination="{
              clickable: true,
            }"
            :lazy="true"
            :navigation="true"
            class="mySwiper w-100"
          >
            <template v-for="item in listimg" :key="item">
              <swiper-slide v-if="item.length > 5">
                <img
                  class="my-card-img"
                  v-lazy="{
                    src:
                      'http://res.cloudinary.com/imageshared/image/upload/c_scale,f_auto,q_auto/v1/' +
                      item,
                    loading: srcload,
                    error: srcerror,
                  }"
                />
              </swiper-slide>
            </template>
          </swiper>
        </div>
      </div>
      <div class="col-12 col-md-5">
        <div class="title-name">
          <h3 class="fw-bold">
            {{ product.name }}
          </h3>
          <div class="title-bage mb-4 mt-2">
            <span class="card-new badge bg-primary" style="margin-right: 10px"
              >NEW</span
            >
            <span v-if="product.saleOff > 0" class="card-sale badge bg-danger"
              >-{{ 100 - CeilPrice(product.saleOff, product.price) }}%</span
            >
          </div>

          <div class="title-code">
            SKU: ASP.NET CORE -{{ product.productId }}
          </div>
        </div>
        <div class="content-price d-flex mt-3">
          <p
            style="margin-right: 20px"
            class="text-danger"
            v-if="product.saleOff > 0"
          >
            {{ product.saleOff }}$
          </p>
          <del v-if="product.saleOff > 0" class="grey-text"
            >{{ product.price }}$</del
          >
          <p v-else class="text-danger">{{ product.price }}$</p>
        </div>

        <div class="color row">
          <div class="col-2">
            <div class="fw-bold">Color:</div>
          </div>
          <div class="layered-content filter-color s-filter swatch col-10">
            <div class="select-swap d-flex flex-wrap">
              <div
                v-for="(item, index) in color"
                :key="item.code"
                class="selectcolor"
              >
                <div
                  v-if="index == 0"
                  :class="+item.nameColor + ' swatch-element checked'"
                  :id="item.nameColor"
                >
                  <input
                    type="radio"
                    name="option2"
                    class="variant-1"
                    :id="'swatch-1 ' + item.nameColor"
                    :value="item.nameColor"
                  />
                  <label
                    v-bind:data-value="item.nameColor"
                    v-on:click="selectcl"
                    class="lbSwatch"
                    :for="'swatch-1 ' + item.nameColor"
                    :style="'background-color:' + item.code"
                  >
                    <img
                      alt="sold-out"
                      src="http://theme.hstatic.net/1000253775/1000734768/14/soldout.png"
                      class="crossed-out" />
                    <img
                      alt="select-pro"
                      src="http://theme.hstatic.net/1000253775/1000734768/14/select-pro.png"
                      class="img-check"
                  /></label>
                </div>
                <div
                  v-else
                  :class="+item.nameColor + ' swatch-element'"
                  :id="item.nameColor"
                >
                  <input
                    type="radio"
                    name="option2"
                    class="variant-1"
                    :id="'swatch-1 ' + item.nameColor"
                    :value="item.nameColor"
                  />
                  <label
                    v-bind:data-value="item.nameColor"
                    v-on:click="selectcl"
                    class="lbSwatch"
                    :for="'swatch-1 ' + item.nameColor"
                    :style="'background-color:' + item.code"
                  >
                    <img
                      alt="sold-out"
                      src="http://theme.hstatic.net/1000253775/1000734768/14/soldout.png?v=885"
                      class="crossed-out" />
                    <img
                      alt="select-pro"
                      src="http://theme.hstatic.net/1000253775/1000734768/14/select-pro.png?v=885"
                      class="img-check"
                  /></label>
                </div>
              </div>
              <div></div>
              <!---->
            </div>
          </div>
        </div>

        <div class="size row mt-3">
          <div class="fw-bold col-2" style="padding-top: 16px">Size:</div>
          <div class="layered-content filter-color s-filter swatch col-10">
            <div class="select-swap d-flex flex-wrap">
              <div v-for="(item, index) in size" :key="item" class="selectsize">
                <div
                  v-if="index < 1"
                  :class="+item.sizeProduc + ' swatch-element checked '"
                  :id="item.sizeProduc"
                >
                  <input
                    type="radio"
                    name="option2"
                    class="variant-1"
                    :id="'swatch-1-' + item.sizeProduc"
                    :value="item.sizeProduc"
                  />
                  <label
                    v-bind:data-value="item.sizeProduc"
                    v-on:click="selectSize"
                    class="lbSwatch"
                    :for="'swatch-1-' + item.sizeProduc"
                  >
                    {{ item.sizeProduc }}
                    <img
                      alt="sold-out"
                      src="http://theme.hstatic.net/1000253775/1000734768/14/soldout.png"
                      class="crossed-out" /><img
                      alt="select-pro"
                      src="http://theme.hstatic.net/1000253775/1000734768/14/select-pro.png"
                      class="img-check"
                  /></label>
                </div>
                <div
                  v-else
                  :class="+item.sizeProduc + ' swatch-element '"
                  :id="item.sizeProduc"
                >
                  <input
                    type="radio"
                    name="option2"
                    class="variant-1"
                    :id="'swatch-1-' + item.sizeProduc"
                    :value="item.sizeProduc"
                  />
                  <label
                    v-bind:data-value="item.sizeProduc"
                    v-on:click="selectSize"
                    class="lbSwatch"
                    :for="'swatch-1-' + item.sizeProduc"
                  >
                    {{ item.sizeProduc }}
                    <img
                      alt="sold-out"
                      src="http://theme.hstatic.net/1000253775/1000734768/14/soldout.png"
                      class="crossed-out" /><img
                      alt="select-pro"
                      src="http://theme.hstatic.net/1000253775/1000734768/14/select-pro.png"
                      class="img-check"
                  /></label>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="xuatxu row mt-3">
          <div class="fw-bold col-3">Xuất xứ:</div>
          <div class="col-5">{{ product.factory }}</div>
        </div>
        <hr />

        <div class="count-product d-flex">
          <button v-on:click="minus" type="button">-</button>
          <div class="md-form md-outline quantity">
            <input type="text" id="form1" :value="count" class="form-control" />
            <label for="form1" class="active">Số lượng</label>
          </div>
          <button v-on:click="add" type="button">+</button>
        </div>

        <div class="d-flex btn-cart">
          <button type="button" color="primary" class="ml-0 btn-primary btn">
            Mua ngay
          </button>
          <button type="button" color="success" class="btn-success btn ms-3">
            <i class="fa-cart-plus mr-1 fas"></i>Thêm vào giỏ hàng
          </button>
        </div>
      </div>
      <hr class="mt-2" />
    </div>
  </div>

  <div class="review m-2">
    <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
      <li class="nav-item" role="presentation">
        <button
          class="nav-link active"
          id="pills-home-tab"
          data-bs-toggle="pill"
          data-bs-target="#pills-home"
          type="button"
          role="tab"
          aria-controls="pills-home"
          aria-selected="true"
        >
          Thông tin
        </button>
      </li>
      <li class="nav-item" role="presentation">
        <button
          class="nav-link"
          id="pills-profile-tab"
          data-bs-toggle="pill"
          data-bs-target="#pills-profile"
          type="button"
          role="tab"
          aria-controls="pills-profile"
          aria-selected="false"
        >
          Review
        </button>
      </li>
    </ul>
    <div class="tab-content" id="pills-tabContent">
      <div
        class="tab-pane fade show active"
        id="pills-home"
        role="tabpanel"
        aria-labelledby="pills-home-tab"
      >
        <div v-html="product.body"></div>
      </div>
      <div
        class="tab-pane fade"
        id="pills-profile"
        role="tabpanel"
        aria-labelledby="pills-profile-tab"
      ></div>
    </div>
  </div>
  <hr />
</template>
<script>
import HomeService from "../service/Home";
// Import Swiper Vue.js components
import { Swiper, SwiperSlide } from "swiper/vue";
import ListProducts from "../components/ListProducts.vue";
// Import Swiper styles
import "swiper/swiper.scss";

import "swiper/components/pagination/pagination.min.css";
import "swiper/components/navigation/navigation.min.css";

// import Swiper core and required modules
import SwiperCore, { Pagination, Navigation } from "swiper/core";
import srcld from "../assets/ld.gif";
import srcer from "../assets/er.jpg";
// install Swiper modules
SwiperCore.use([Pagination, Navigation]);
import Products from "../service/Products";
import { useRoute } from "vue-router";

export default {
  components: {
    Swiper,
    SwiperSlide,
  },
  data() {
    return {
      products: null,
      product: [],
      color: null,
      size: null,
      listimg: [],
      srcerror: srcer,
      srcload: srcld,
      count: 1,
      slsize: null,
      slcolor: null,
      ll: null,
      idsrc: this.id,
    };
  },
  props: {
    id: String,
  },
  homeService: null,
  productService: null,
  created() {
    this.productService = new Products();
    this.homeService = new HomeService();
    this.homeService.getListProducts().then((data) => {
      this.ll = data;
    });

    // const route = useRoute();

    this.productService.getProductsId(this.idsrc).then((data) => {
      (this.products = data),
        (this.listimg = data.product.image.split(",")),
        (this.product = data.product),
        (this.color = data.getColors),
        (this.size = data.getSizes);
    });
  },
  mounted() {},

  methods: {
    watch: {
      $route(to, from) {},
    },
    getImage(img) {
      return img.split(",")[1];
    },
    CeilPrice(a, b) {
      return Math.ceil((a / b) * 100);
    },
    add() {
      this.count = this.count + 1;
      console.log(this.count);
    },
    minus() {
      if (this.count == 1) this.count = 1;
      else this.count = this.count - 1;
      console.log(this.count);
    },
    selectSize(event) {
      this.slsize = event.target.getAttribute("data-value");
      for (
        let index = 0;
        index < document.getElementsByClassName("selectsize").length;
        index++
      ) {
        const element = document.getElementsByClassName("selectsize")[index];
        element.children[0].className = element.children[0].className.replace(
          " checked",
          ""
        );
      }
      event.target.parentNode.className =
        event.target.parentNode.className + " checked";
    },
    selectcl(event) {
      this.slcolor = event.target.getAttribute("data-value");
      for (
        let index = 0;
        index < document.getElementsByClassName("selectcolor").length;
        index++
      ) {
        const element = document.getElementsByClassName("selectcolor")[index];
        element.children[0].className = element.children[0].className.replace(
          " checked",
          ""
        );
      }
      event.target.parentNode.className =
        event.target.parentNode.className + " checked";
    },
  },
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
.grey-text {
  color: #9e9e9e !important;
}
.text-danger {
  color: #ff3547 !important;
}

.product-gallery__thumbs-container {
  width: 7%;
}
.product-gallery__thumbs {
  box-sizing: border-box;
  width: 100%;
  position: sticky;
  top: 65px;
  padding-bottom: 1px;
}
.product-gallery__thumb a {
  background-color: #f3f3f3;
  display: block;
}
.product-gallery__thumb {
  line-height: 0;
  margin-bottom: 10px;
  border: 1px solid #f7f7f8;
  width: 100%;
}
.product-gallery__thumb:last-child {
  margin-bottom: 0;
}
.product-gallery__thumb:hover {
  border-color: #a3a5a7;
}
.product-gallery__thumb img {
  cursor: pointer;
  background-color: #f7f7f8;
  width: 100%;
}
.product-gallery__thumb.active,
.product-gallery__thumb.active:hover {
  border-color: #808284;
}
.product-gallery__thumb.active img {
  opacity: 0.9;
  width: 100%;
}
.product-gallery {
  display: flex;
}
.product-image-detail {
  width: 93%;
  padding-left: 10px;
  position: relative;
}
.product-gallery-item {
  text-align: center;
  margin-bottom: 10px;
}
.product-full-img {
  text-align: center;
}
.product-full-img .no_image {
  width: 50%;
}
.content-filter .option {
  margin-top: 30px;
}
.option .lb-filter {
  display: block;
  font-size: 15px;
  opacity: 0.92;
  margin-bottom: 0;
}
.custom-dropdown {
  display: inline-block;
  position: relative;
  vertical-align: middle;
  max-width: 100%;
  overflow: hidden;
  border-radius: 0;
}
.custom-dropdown:after {
  content: "";
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
  border-radius: 0;
  -moz-appearance: none;
  -webkit-appearance: none;
  cursor: pointer;
  text-indent: 1px;
}
.option .custom-dropdown {
  width: 100%;
}
.option .custom-dropdown:after {
  content: "";
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
  padding: 10px 0;
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
  content: "";
}
.group-filter[aria-expanded="false"] .layered-content {
  display: none;
  height: 0;
}
.group-filter[aria-expanded="true"] .layered-content {
  height: auto;
}
.group-filter .layered-content {
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
  font-weight: 400;
  margin-bottom: 0;
  color: #252a2b;
}
.check-box-list li:hover label {
  color: #e00000;
}
.check-box-list input[type="checkbox"] {
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
.filter-color li input[type="checkbox"]:checked + label:before {
  position: absolute;
  transform: rotate(-45deg);
  content: "";
  border-width: 0 0 2px 2px !important;
  height: 5px;
  width: 9px;
  z-index: 99;
  border: solid #fff;
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
.bl-filter [type="checkbox"]:checked,
.bl-filter [type="checkbox"]:not(:checked) {
  position: absolute;
  left: -9999px;
}
.bl-filter [type="checkbox"]:checked + label,
.bl-filter [type="checkbox"]:not(:checked) + label {
  position: relative;
  padding-left: 22px;
  cursor: pointer;
}
.bl-filter [type="checkbox"]:checked + label:before,
.bl-filter [type="checkbox"]:not(:checked) + label:before {
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
.bl-filter [type="checkbox"]:checked + label:after,
.bl-filter [type="checkbox"]:not(:checked) + label:after {
  position: absolute;
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
.product-image-detail ul {
  margin: 0;
}
.select,
.selector-wrapper {
  display: none;
}
.swatch .header {
  margin: 0 0 8px;
  font-size: 13px;
  text-align: left;
  line-height: normal;
}
.swatch > label.tt-label {
  margin-right: 10px;
  font-size: 14px;
  font-weight: 500;
  vertical-align: middle;
  text-transform: uppercase;
  width: 85px;
  text-align: right;
}
.swatch input {
  display: none;
}
.swatch .swatch-element {
  display: inline-block;
  margin-right: 8px;
  position: relative;
  vertical-align: bottom;
  margin-top: 10px;
}
.swatch .swatch-element label {
  display: block;
  margin: 0;
  background: #fff;
  min-width: 40px;
  height: 40px;
  line-height: 40px;
  position: relative;
  border: 1px solid #e5e5e5;
  font-size: 12px;
  font-weight: 500;
  text-align: center;
  cursor: pointer;
}
.swatch .swatch-element.color.soldout label span {
  overflow: hidden;
  position: relative;
}
.swatch .swatch-element.color label {
  background-size: 35px 100% !important;
  border: 1px solid #000;
}
.swatch .swatch-element.color span {
  display: inline-block;
  min-width: 110px;
  width: 100%;
  height: 40px;
  margin-top: 0;
  font-size: 12px;
  padding-left: 40px;
  padding-right: 5px;
  color: #000;
}
.swatch .swatch-element .crossed-out {
  display: none;
}
.crossed-out {
  position: absolute;
  width: 100%;
  height: 100%;
  left: 0;
  top: 0;
}
.swatch-element .img-check {
  display: none;
  position: absolute;
  right: 0;
  bottom: 0;
}
.swatch-element .sd .img-check {
  display: block;
}
.swatch .swatch-element label.sd {
  color: #000;
  padding: 0 3px;
}
.swatch .swatch-element.soldout:not(.color) label {
  overflow: hidden;
}
.swatch .swatch-element.soldout:not(.color) label:before {
  content: "";
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  margin: auto;
  width: 50%;
  height: 50%;
  background: url(//theme.hstatic.net/1000253775/1000662899/14/sold_out.png?v=879)
    no-repeat;
  background-size: contain;
}

.count-product button {
  background: #4285f4;
  outline: none;
  width: 38px;
  height: 38px;
  border: 0;
  border-radius: 10%;
  font-size: 26px;
  color: #fff;
}
#product-select-option-0,
#product-select-option-1,
#product-select-option-2,
label[for="product-select-option-0"],
label[for="product-select-option-1"],
label[for="product-select-option-2"] {
  display: none;
}
#product-select-option-0 + .custom-style-select-box,
#product-select-option-1 + .custom-style-select-box,
#product-select-option-2 + .custom-style-select-box {
  display: none !important;
}
@media (max-width: 767px) {
  .swatch .swatch-element.color {
    margin: 5px 8px 5px 0;
  }
}
.swatch-element.checked label img.img-check {
  display: block;
}
.btn-cart button {
  font-size: 10px !important;
}
.info-product .content {
  font-size: 15px;
}
.tabs-products button.active {
  background-color: #4285f4 !important;
  color: #fff;
}
.tabs-products button {
  background-color: #e0e0e0;
}

.count-product .quantity {
  margin-top: 0;
  margin-left: 5px;
  margin-right: 5px;
}
.md-form.md-outline {
  position: relative;
  margin-bottom: 1.5rem;
}
.md-form {
  margin-bottom: 2rem;
}
.md-form {
  position: relative;
  margin-top: 1.5rem;
  margin-bottom: 1.5rem;
}
.md-form.md-outline input[type="date"],
.md-form.md-outline input[type="datetime-local"],
.md-form.md-outline input[type="email"],
.md-form.md-outline input[type="number"],
.md-form.md-outline input[type="password"],
.md-form.md-outline input[type="search-md"],
.md-form.md-outline input[type="search"],
.md-form.md-outline input[type="tel"],
.md-form.md-outline input[type="text"],
.md-form.md-outline input[type="time"],
.md-form.md-outline input[type="url"],
.md-form.md-outline textarea.md-textarea {
  transition: all 0.3s;
  outline: none;
  box-shadow: none;
  border: 1px solid #dadce0;
  border-radius: 4px;
  background-color: initial;
  box-sizing: border-box;
}

.md-form.md-outline .form-control {
  padding: 0.375rem 0.75rem;
}
.md-form input[type="date"],
.md-form input[type="datetime-local"],
.md-form input[type="email"],
.md-form input[type="number"],
.md-form input[type="password"],
.md-form input[type="search-md"],
.md-form input[type="search"],
.md-form input[type="tel"],
.md-form input[type="text"],
.md-form input[type="time"],
.md-form input[type="url"],
.md-form textarea.md-textarea {
  transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
  outline: none;
  box-shadow: none;
  border: none;
  border-bottom: 1px solid #ced4da;
  border-radius: 0;
  box-sizing: initial;
  background-color: initial;
}
.md-form .form-control {
  margin: 0 0 0.5rem;
  border-radius: 0;
  padding: 0.6rem 0 0.4rem;
  background-color: initial;
  height: auto;
}
@media (prefers-reduced-motion: reduce) {
  .form-control {
    transition: none;
  }
}
.form-control {
  display: block;
  width: 100%;
  height: calc(1.5em + 0.75rem + 2px);
  padding: 0.375rem 0.75rem;
  font-size: 1rem;
  font-weight: 400;
  line-height: 1.5;
  color: #495057;
  background-color: #fff;
  background-clip: padding-box;
  border: 1px solid #ced4da;
  border-radius: 0.25rem;
  transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
}
button,
input {
  overflow: visible;
}
button,
input,
optgroup,
select,
textarea {
  margin: 0;
  font-family: inherit;
  font-size: inherit;
  line-height: inherit;
}
.md-form.md-outline label.active {
  transform: translateY(-13px) scale(0.8);
  background: #fff;
  font-weight: 500;
  padding-right: 5px;
  padding-left: 5px;
  left: 8px;
}
.md-form label:not(.form-check-label).active {
  max-width: 123%;
}
.md-form label.active {
  color: #757575;
}
.md-form.md-outline label {
  font-size: 1rem !important;
  position: absolute;
  top: 0;
  left: 0;
  padding-left: 10px;
  transition: transform 0.2s ease-out, color 0.2s ease-out,
    max-width 0.2 ease-out;
  transform-origin: 0 100%;
  transform: translateY(9px);
  cursor: text;
  color: #757575;
}
.md-form label:not(.form-check-label) {
  transition: transform 0.2s ease-out, color 0.2s ease-out,
    max-width 0.2s ease-out;
  text-overflow: ellipsis;
  overflow: hidden;
  white-space: nowrap;
  max-width: 100%;
}
.md-form label.active {
  transform: translateY(-14px) scale(0.8);
}
.md-form label.active {
  font-size: 1rem;
}
.md-form label {
  left: 0;
}
.md-form label {
  position: absolute;
  top: 0;
  font-size: 1rem;
  transition: transform 0.2s ease-out, color 0.2s ease-out;
  transform-origin: 0 100%;
  transform: translateY(12px);
  cursor: text;
  color: #757575;
}
label {
  display: inline-block;
  margin-bottom: 0.5rem;
}
.btn-success {
  background-color: #00c851 !important;
  color: #fff;
}
.btn {
  box-shadow: 0 2px 5px 0 rgb(0 0 0 / 16%), 0 2px 10px 0 rgb(0 0 0 / 12%);
  padding: 0.84rem 2.14rem;
  font-size: 0.81rem;
  transition: all 0.2s ease-in-out;
  margin: 0.375rem;
  border: 0;
  border-radius: 0.125rem;
  cursor: pointer;
  text-transform: uppercase;
  white-space: normal;
  word-wrap: break-word;
  color: white;
}
</style>