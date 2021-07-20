<template>
  <header>
    <div
      id="menudesktop"
      class="
        d-flex
        justify-content-between
        shift
        menu-scroll
        navbar navbar-expand-sm navbar-toggleable-sm navbar-light
        bg-white
        border-bottom
        box-shadow
        mb-3
      "
    >
      <a class="navbar-brand d-none d-lg-block mb-3" href="/">
        <img class="w-25" src="../assets/logo.png" />
      </a>
      <a href="" class="btn-show-mobile d-block d-lg-none">
        <span class="navbar-toggler-icon"></span>
      </a>

      <div class="mt-3 d-none d-lg-block" id="menu-hide">
        <div id="nav">
          <nav class="main-nav text-center">
            <ul class="clearfix">
              <li>
                <router-link to="/">Trang chủ</router-link>
              </li>
              <li>
                <a href="/Home/Search">Tìm kiếm</a>
              </li>
              <li>
                <a href="/Home/Privacy">
                  Sản phẩm <i class="fa fa-chevron-down" aria-hidden="true"></i>
                </a>

                <ul class="sub_menu">
                  <li v-for="item in menu" :key="item">
                    <router-link
                      :to="{ name: 'ListProducts', params: { id: item.pcId } }"
                    >
                      {{ item.name }}
                      <i class="fa fa-chevron-right" aria-hidden="true"></i>
                    </router-link>
                    <ul class="sub_menu">
                      <li v-for="item1 in item.selectParents" :key="item1">
                        <router-link
                          :to="{
                            name: 'ListProducts',
                            params: { id: item1.pcId },
                          }"
                        >
                          {{ item1.name }}
                        </router-link>
                        <!-- </li>
                      <li>
                        <router-link to="/about/2">Váy ngắn</router-link>
                      </li>
                      <li>
                        <router-link to="/about/3">Váy ngắn</router-link>
                      </li> -->
                      </li>
                    </ul>
                  </li>
                </ul>
              </li>
              <li>
                <router-link :to="{ name: 'Blog' }"> Blog </router-link>
              </li>
              <li>
                <a class="" href="/Home/Privacy">Liên hệ</a>
              </li>
              <li>
                <a class="" href="/tra-cuu-don-hang">Tra cứu đơn hàng</a>
              </li>
              <li>
                <a class="" href="/Home/Privacy"> Bộ sưu tập</a>
              </li>
            </ul>
          </nav>
        </div>
      </div>

      <div class="icon-header">
        <div class="d-flex">
          <a style="color: black !important" href="/Home/Search">
            <svg
              width="1em"
              height="1em"
              viewBox="0 0 16 16"
              class="bi bi-search"
              fill="currentColor"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                fill-rule="evenodd"
                d="M10.442 10.442a1 1 0 0 1 1.415 0l3.85 3.85a1 1 0 0 1-1.414 1.415l-3.85-3.85a1 1 0 0 1 0-1.415z"
              ></path>
              <path
                fill-rule="evenodd"
                d="M6.5 12a5.5 5.5 0 1 0 0-11 5.5 5.5 0 0 0 0 11zM13 6.5a6.5 6.5 0 1 1-13 0 6.5 6.5 0 0 1 13 0z"
              ></path>
            </svg>
          </a>
          <a
            class=""
            style="color: black"
            href="/Home/Account?idview=infoaccount"
          >
            <svg
              width="1em"
              height="1em"
              viewBox="0 0 16 16"
              class="bi bi-people"
              fill="currentColor"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                fill-rule="evenodd"
                d="M15 14s1 0 1-1-1-4-5-4-5 3-5 4 1 1 1 1h8zm-7.995-.944v-.002.002zM7.022 13h7.956a.274.274 0 0 0 .014-.002l.008-.002c-.002-.264-.167-1.03-.76-1.72C13.688 10.629 12.718 10 11 10c-1.717 0-2.687.63-3.24 1.276-.593.69-.759 1.457-.76 1.72a1.05 1.05 0 0 0 .022.004zm7.973.056v-.002.002zM11 7a2 2 0 1 0 0-4 2 2 0 0 0 0 4zm3-2a3 3 0 1 1-6 0 3 3 0 0 1 6 0zM6.936 9.28a5.88 5.88 0 0 0-1.23-.247A7.35 7.35 0 0 0 5 9c-4 0-5 3-5 4 0 .667.333 1 1 1h4.216A2.238 2.238 0 0 1 5 13c0-1.01.377-2.042 1.09-2.904.243-.294.526-.569.846-.816zM4.92 10c-1.668.02-2.615.64-3.16 1.276C1.163 11.97 1 12.739 1 13h3c0-1.045.323-2.086.92-3zM1.5 5.5a3 3 0 1 1 6 0 3 3 0 0 1-6 0zm3-2a2 2 0 1 0 0 4 2 2 0 0 0 0-4z"
              ></path>
            </svg>
          </a>
          <a class="cart-count" href="/gio-hang/thong-tin">
            <svg
              width="1em"
              height="1em"
              viewBox="0 0 16 16"
              class="bi bi-cart4"
              fill="currentColor"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                fill-rule="evenodd"
                d="M0 2.5A.5.5 0 0 1 .5 2H2a.5.5 0 0 1 .485.379L2.89 4H14.5a.5.5 0 0 1 .485.621l-1.5 6A.5.5 0 0 1 13 11H4a.5.5 0 0 1-.485-.379L1.61 3H.5a.5.5 0 0 1-.5-.5zM3.14 5l.5 2H5V5H3.14zM6 5v2h2V5H6zm3 0v2h2V5H9zm3 0v2h1.36l.5-2H12zm1.11 3H12v2h.61l.5-2zM11 8H9v2h2V8zM8 8H6v2h2V8zM5 8H3.89l.5 2H5V8zm0 5a1 1 0 1 0 0 2 1 1 0 0 0 0-2zm-2 1a2 2 0 1 1 4 0 2 2 0 0 1-4 0zm9-1a1 1 0 1 0 0 2 1 1 0 0 0 0-2zm-2 1a2 2 0 1 1 4 0 2 2 0 0 1-4 0z"
              ></path>
            </svg>
            <div class="text-center text-white bg-danger pb-2">0</div>
          </a>
        </div>
      </div>
    </div>

    <div id="page" class="d-block d-lg-none container-fluid mb-2">
      <div class="header">
        <a class="" href="#menu" id="click"><span></span></a>
        Demo
      </div>

      <nav id="menu">
        <ul>
          <li><a href="#">Home</a></li>
          <li>
            <span>Sản phẩm</span>
            <ul>
              <li v-for="item in menu" :key="item">
                <router-link
                  :to="{ name: 'ListProducts', params: { id: item.pcId } }"
                >
                  {{ item.name }}
                </router-link>
                <ul class="sub_menu">
                  <li v-for="item1 in item.selectParents" :key="item1">
                    <router-link
                      :to="{
                        name: 'ListProducts',
                        params: { id: item1.pcId },
                      }"
                    >
                      {{ item1.name }}
                    </router-link>
                  </li>
                </ul>
              </li>
            </ul>
          </li>
          <li><a href="#contact">Contact</a></li>

          <li class="Divider">Other demos</li>
          <li><a href="advanced.html">Advanced demo</a></li>
          <li><a href="onepage.html">One page demo</a></li>
        </ul>
      </nav>

      <div class="icon-header">
        <div class="d-flex">
          <a
            style="color: black !important"
            asp-controller="Home"
            asp-route-searchString=""
            asp-action="Search"
          >
            <svg
              width="1em"
              height="1em"
              viewBox="0 0 16 16"
              class="bi bi-search"
              fill="currentColor"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                fill-rule="evenodd"
                d="M10.442 10.442a1 1 0 0 1 1.415 0l3.85 3.85a1 1 0 0 1-1.414 1.415l-3.85-3.85a1 1 0 0 1 0-1.415z"
              />
              <path
                fill-rule="evenodd"
                d="M6.5 12a5.5 5.5 0 1 0 0-11 5.5 5.5 0 0 0 0 11zM13 6.5a6.5 6.5 0 1 1-13 0 6.5 6.5 0 0 1 13 0z"
              />
            </svg>
          </a>
          <a
            asp-action="Account"
            asp-controller="Home"
            asp-route-idview="infoaccount"
            class=""
            style="color: black"
          >
            <svg
              width="1em"
              height="1em"
              viewBox="0 0 16 16"
              class="bi bi-people"
              fill="currentColor"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                fill-rule="evenodd"
                d="M15 14s1 0 1-1-1-4-5-4-5 3-5 4 1 1 1 1h8zm-7.995-.944v-.002.002zM7.022 13h7.956a.274.274 0 0 0 .014-.002l.008-.002c-.002-.264-.167-1.03-.76-1.72C13.688 10.629 12.718 10 11 10c-1.717 0-2.687.63-3.24 1.276-.593.69-.759 1.457-.76 1.72a1.05 1.05 0 0 0 .022.004zm7.973.056v-.002.002zM11 7a2 2 0 1 0 0-4 2 2 0 0 0 0 4zm3-2a3 3 0 1 1-6 0 3 3 0 0 1 6 0zM6.936 9.28a5.88 5.88 0 0 0-1.23-.247A7.35 7.35 0 0 0 5 9c-4 0-5 3-5 4 0 .667.333 1 1 1h4.216A2.238 2.238 0 0 1 5 13c0-1.01.377-2.042 1.09-2.904.243-.294.526-.569.846-.816zM4.92 10c-1.668.02-2.615.64-3.16 1.276C1.163 11.97 1 12.739 1 13h3c0-1.045.323-2.086.92-3zM1.5 5.5a3 3 0 1 1 6 0 3 3 0 0 1-6 0zm3-2a2 2 0 1 0 0 4 2 2 0 0 0 0-4z"
              />
            </svg>
          </a>
          <a
            class="cart-count"
            asp-controller="ShoppingCart"
            asp-action="Index"
          >
            <svg
              width="1em"
              height="1em"
              viewBox="0 0 16 16"
              class="bi bi-cart4"
              fill="currentColor"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                fill-rule="evenodd"
                d="M0 2.5A.5.5 0 0 1 .5 2H2a.5.5 0 0 1 .485.379L2.89 4H14.5a.5.5 0 0 1 .485.621l-1.5 6A.5.5 0 0 1 13 11H4a.5.5 0 0 1-.485-.379L1.61 3H.5a.5.5 0 0 1-.5-.5zM3.14 5l.5 2H5V5H3.14zM6 5v2h2V5H6zm3 0v2h2V5H9zm3 0v2h1.36l.5-2H12zm1.11 3H12v2h.61l.5-2zM11 8H9v2h2V8zM8 8H6v2h2V8zM5 8H3.89l.5 2H5V8zm0 5a1 1 0 1 0 0 2 1 1 0 0 0 0-2zm-2 1a2 2 0 1 1 4 0 2 2 0 0 1-4 0zm9-1a1 1 0 1 0 0 2 1 1 0 0 0 0-2zm-2 1a2 2 0 1 1 4 0 2 2 0 0 1-4 0z"
              ></path>
            </svg>
            <div class="text-center text-white bg-danger pb-2">2</div>
          </a>
        </div>
      </div>
    </div>
  </header>
</template>
<script>
import HomeService from "../service/Home";
export default {
  data() {
    return {
      menu: [],
    };
  },
  name: "Header",
  homeService: null,
  created() {
    this.homeService = new HomeService();
  },
  mounted() {
    this.homeService.getMenu().then((data) => {
      this.menu = data;
    });
  },
};
</script>
<style scoped>
@media (max-width: 992px) {
  #menudesktop {
    display: none !important;
  }
  .mm-listitem .mm-listitem__text i {
    display: none !important;
  }
}
.navbar {
  position: relative;
  border: 1px solid #f1f1f1;
  transition: all 0.2s;
}

.box-shadow {
  box-shadow: 0 0.25rem 0.75rem rgb(0 0 0 / 5%);
}
a.navbar-brand {
  white-space: normal;
  text-align: center;
  word-break: break-all;
}

a.navbar-brand {
  white-space: normal;
  text-align: center;
  word-break: break-all;
}
i:hover {
  cursor: pointer;
}
/* Provide sufficient contrast against white background */
a {
  transition: all 0.2s;
  color: #48cab2;
  text-decoration: none;
}
a:hover {
  color: #48cab2;
}

html {
  font-size: 14px;
  cursor: pointer;
}
@media (min-width: 768px) {
  html {
    font-size: 16px;
  }
}

.box-shadow {
  box-shadow: 0 0.25rem 0.75rem rgba(0, 0, 0, 0.05);
}

li {
  margin-bottom: 10px;
}
ul {
  list-style: none;
}

html {
  position: relative;
  min-height: 100%;
}
body {
  /* Margin bottom by footer height */
  margin-bottom: 60px;
}
.cart-name-product {
  display: inline-block;
  font-family: Roboto;
  font-style: normal;
  font-weight: 500;
  font-size: 16px;
  line-height: 19px;
  text-transform: uppercase;
  color: #333333;
}

.cart-count {
  position: relative;
  color: black;
}
.cart-count div {
  position: absolute;
  top: -50%;
  right: 10%;
  height: 20px;
  width: 20px;
  border-radius: 50px;
}
header {
  position: relative;
}
header i {
  margin-right: 10px;
  font-size: 25px;
}
header .btn-show-mobile {
  color: rgba(0, 0, 0, 0.5);
  border-color: rgba(0, 0, 0, 0.1);
  padding: 0.25rem 0.75rem;
  font-size: 1.25rem;
  line-height: 1;
  background-color: transparent;
  border: 1px solid transparent;
  border-radius: 0.25rem;
}
header #menu-hide .navbar-nav li {
  position: relative;
}
header #menu-hide .navbar-nav li ul {
  padding: 25px 27px 10px 27px;
  background: white !important;
  height: 0;
  left: 0;
  opacity: 0;
  position: absolute;
  transition: all 0.2s;
  top: 22px;
  width: auto;
  border-top: 1px solid;
  display: none;
}
header #menu-hide .navbar-nav li ul li a {
  transition: all 0.5s ease;
  display: block;
  text-decoration: none;
  border-bottom: 1px solid #e5e5e5;
  color: black;
}
header #menu-hide .navbar-nav li ul li .menu-item-product-children {
  z-index: 999;
  top: 100%;
  left: 100%;
  height: 0;
  left: 0;
  display: none;
  opacity: 0;
}
header #menu-hide .navbar-nav li ul li:hover a {
  transform: translateX(5px);
  color: #48cab2;
  border-bottom-color: black;
}
header #menu-hide .navbar-nav li ul li:hover .menu-item-product-children {
  opacity: 1;
  display: block;
  z-index: 99;
  height: auto;
  left: 100%;
}
header #menu-hide .navbar-nav li:hover ul {
  height: auto;
  z-index: 99;
  opacity: 1;
  transform: translateY(0);
  display: block;
  left: 19%;
}
.navbar {
  position: relative;
  border: 1px solid #f1f1f1;
  transition: all 0.2s;
}

.bi {
  margin-right: 10px;
  font-size: 25px;
}
.bi-star-fill {
  font-size: 15px;
}

@media (min-width: 992px) {
  .title-main-ct {
    font-size: 14px !important;
  }
  .menu-desktop {
    position: relative;
    display: -webkit-flex;
    display: flex;
    -webkit-justify-content: center;
    -moz-justify-content: center;
    justify-content: center;
  }

  #nav nav.main-nav ul li a {
    color: #000000;
    text-decoration: none;
  }
  #nav nav.main-nav ul li a:hover {
    color: #48cab2;
  }
  #nav .main-nav > ul > li {
    float: left;
    z-index: 10;
  }
  #nav .main-nav > ul > li > a {
    display: block;
    font-size: 15px;
    font-weight: 400;
    padding: 10px 0 15px;
    margin: 0 25px 0 0;
    position: relative;
  }
  #nav .main-nav > ul > li > a:before {
    position: absolute;
    content: "";
    bottom: 0;
    left: 0;
    width: 100%;
    opacity: 0;
    -webkit-transform: scale(0, 1);
    transform: scale(0, 1);
    -webkit-transform-origin: left center;
    transform-origin: left center;
    border-bottom: 2px solid #5c5c5c;
    -webkit-transition: opacity 0.3s, -webkit-transform 0.3s;
    transition: opacity 0.3s, -webkit-transform 0.3s;
    transition: transform 0.3s, opacity 0.3s;
    transition: transform 0.3s, opacity 0.3s, -webkit-transform 0.3s;
  }
  #nav .main-nav > ul > li > a:hover:before,
  #nav .main-nav > ul > li.active > a:before {
    opacity: 1;
    -webkit-transform: scale(1, 1);
    transform: scale(1, 1);
  }
  #nav .main-nav ul {
    padding-left: 0;
    margin: 0;
  }
  #nav .main-nav ul > li a i {
    display: inline-block;
    vertical-align: middle;
    font-size: 9px;
    margin-left: 4px;
    margin-bottom: 2px;
  }
  #nav .main-nav .sub_menu {
    background: #fff;
    position: absolute;
    z-index: 999;
    -webkit-box-shadow: 0 1px 1px rgba(0, 0, 0, 0.05);
    -moz-box-shadow: 0 1px 1px rgba(0, 0, 0, 0.05);
    -o-box-shadow: 0 1px 1px rgba(0, 0, 0, 0.05);
    -ms-box-shadow: 0 1px 1px rgba(0, 0, 0, 0.05);
    box-shadow: 0 1px 1px rgba(0, 0, 0, 0.05);
    -webkit-transform: rotate3d(1, 0, 0, -90deg);
    -moz-transform: rotate3d(1, 0, 0, -90deg);
    -o-transform: rotate3d(1, 0, 0, -90deg);
    -ms-transform: rotate3d(1, 0, 0, -90deg);
    transform: rotate3d(1, 0, 0, -90deg);
    -webkit-transform-origin: 0 0 0;
    -moz-transform-origin: 0 0 0;
    -o-transform-origin: 0 0 0;
    -ms-transform-origin: 0 0 0;
    transform-origin: 0 0 0;
    -webkit-transition: all 0.5s ease;
    -moz-transition: all 0.5s ease;
    -o-transition: all 0.5s ease;
    transition: all 0.5s ease;
  }
  #nav .main-nav ul > li > ul {
    top: 100%;
    margin-top: -2px;
    border-top: 2px solid #5c5c5c;
  }
  #nav .main-nav li:hover > .sub_menu {
    -webkit-transform: rotate3d(0, 0, 0, 0deg);
    -moz-transform: rotate3d(0, 0, 0, 0deg);
    -o-transform: rotate3d(0, 0, 0, 0deg);
    -ms-transform: rotate3d(0, 0, 0, 0deg);
    transform: rotate3d(0, 0, 0, 0deg);
  }
  #nav .main-nav .sub_menu a {
    padding: 9px 18px;
    white-space: nowrap;
    text-align: left;
    display: block;
    font-size: 14px;
  }
  #nav .main-nav .sub_menu .sub_menu {
    left: 100%;
    top: 0;
    margin-left: 1px;
    margin-top: 0;
    -webkit-transform: rotate3d(0, 1, 0, 90deg);
    -moz-transform: rotate3d(0, 1, 0, 90deg);
    -o-transform: rotate3d(0, 1, 0, 90deg);
    -ms-transform: rotate3d(0, 1, 0, 90deg);
    transform: rotate3d(0, 1, 0, 90deg);
  }
  #nav .main-nav .sub_menu li:not(:first-child) {
    border-top: 1px solid #ecf0f1;
  }
  #nav .main-nav ul > li i {
    -webkit-transition: 0.2s;
    -moz-transition: 0.2s;
    -o-transition: 0.2s;
    transition: 0.2s;
  }
  #nav .main-nav ul > li:hover > a i {
    -webkit-transform: rotate(180deg);
    -moz-transform: rotate(180deg);
    -ms-transform: rotate(180deg);
    -o-transform: rotate(180deg);
    transform: rotate(180deg);
    margin-bottom: 0;
  }
}

@media (min-width: 992px) {
  .main-body.sidebar-move
    .box__slideshow-split:not(.back-to-normal)
    .site-box-background-container {
    transform: translateX(-480px);
  }
}
@media (max-width: 992px) {
  #menudesktop {
    display: none !important;
  }
  .mm-listitem .mm-listitem__text i {
    display: none !important;
  }
}
@media (max-width: 767px) {
  /* Header */
  .header-wrap-icon > span {
    display: inline-block !important;
  }
  .site-nav.style--sidebar {
    width: 320px;
  }
  .main-body.sidebar-move {
    right: 320px;
  }
  .site-nav.style--sidebar .site-nav-container {
    width: 100%;
  }
  .site-nav.style--sidebar .site-nav-container-last {
    padding-top: 40px;
    padding-left: 30px;
    padding-right: 30px;
  }
  .site-close-handle {
    top: 35px;
    right: 30px;
  }
  .to-bottom-content {
    left: 30px;
  }
  /* site cart */
  .cart-view a.linktocheckout,
  .cart-view a.linktocart {
    font-size: 11px;
    padding: 15px 8px;
  }
  /* site menu */
  .menu-collection li.navi1 > a {
    font-size: 20px;
  }
  .menu-collection ul.subnav-children li.navi2 > a {
    font-size: 16px;
  }
}

.panel-default > .panel-heading {
  background-color: #fff;
  border: 1px solid #ddd;
}
#page {
  border-top: 1px solid #f1f1f1;
  border-bottom: 1px solid #f1f1f1;
}
#page .icon-header {
  position: absolute;
  top: 0;
  right: 0;
  padding: 11px;
  margin: 2px;
}
.mm-menu_offcanvas {
  width: 43% !important;
}
.mm-listitem__btn:not(.mm-listitem__text) {
  border-left-style: none !important;
}
nav#menu:not(.mm-menu) {
  display: none;
}
#menu {
  margin-top: 5% !important;
}
.header {
  font-size: 16px;
  font-weight: bold;
  line-height: 44px;
  -moz-box-sizing: border-box;
  box-sizing: border-box;
  width: 100%;
  height: 44px;
  padding: 0 50px;
  text-align: center;
}
.header.fixed {
  position: fixed;
  top: 0;
  left: 0;
}
.header a {
  display: block;
  width: 50px;
  height: 44px;
  padding: 11px;
  margin: 2px;
  position: absolute;
  color: black;
  top: 0;
  left: 0;
  margin-left: 18px;
}
.header a:before,
.header a:after {
  content: "";
  display: block;
  background: #000000;
  height: 2px;
}
.header a span {
  background: #000000;
  display: block;
  height: 2px;
  margin: 6px 0;
}
</style>
