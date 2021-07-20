<template>
  <div class="row breadcrumb-shop">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pd5">
      <ol class="breadcrumb breadcrumb-arrows">
        <li><router-link to="/">Trang chủ</router-link></li>
        <li class="active">
          <span> Bài viết</span>
        </li>
      </ol>
    </div>
  </div>
  <section class="my-2 container-fluid">
    <!-- Section heading -->
    <h2 class="h1-responsive font-weight-bold text-center">Bài Viết</h2>
    <!-- Section description -->
    <p class="text-center w-responsive mx-auto mb-5">
      Một sản phẩm được viết bởi Nguyễn Khả Hợp dựa trên kiến trúc MicroService,
      cảm ơn bạn vì đã bỏ chút thời gian để truy cập vào trang web của tớ nha...
    </p>

    <div v-for="item in listarticle" :key="item">
      <div class="row mb-2">
        <!-- Grid column -->
        <div class="col-md-5">
          <!-- Featured image -->
          <div class="view overlay rounded z-depth-2 mb-lg-0 mb-4 waves-light">
            <img
              class="img-fluid"
              :src="'http://res.cloudinary.com/imageshared/image/upload/f_auto,q_auto/v1/'+item.coverImage"
              alt="Sample image"
            />
            <a>
              <div class="mask rgba-white-slight"></div>
            </a>
          </div>
        </div>
        <!-- Grid column -->

        <!-- Grid column -->
        <div class="col-md-7">
          <!-- Category -->
          <a href="#!" class="green-text">
            <h6 class="font-weight-bold mb-3">
              <i class="fa-utensils p-2 fas" style="marg"></i
                >{{ item.nameBlog }}
            </h6>
          </a>
          <!-- Post title -->
          <h3 class="font-weight-bold mb-3">
            <div>{{ item.description }}</div>
          </h3>
          <!-- Excerpt -->
          <p>{{ item.titleMeta }}</p>
          <!-- Post data -->
          <p>
            by <a><strong>Nguyễn Khả Hợp</strong></a
            >, {{ item.createDate.substring(0, 10) }}
          </p>
          <!-- Read more button -->
          <router-link class="btn-success btn" :to="{ name: 'Category', params: { id: item.id } }">
              Chi tiết
          </router-link>
        </div>
        <!-- Grid column -->
      </div>
      <hr class="mt-2" />
    </div>
  </section>
</template>
<script>
import HomeService from "../service/Home";
export default {
  data: () => ({ listarticle: [] }),
  homeService: null,
  created() {
    this.homeService = new HomeService();
    this.homeService.getListArticle().then((data) => {
      this.listarticle = data;
    });
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
.btn-success {
    background-color: #00c851!important;
    color: #fff;
}
.btn {
    box-shadow: 0 2px 5px 0 rgb(0 0 0 / 16%), 0 2px 10px 0 rgb(0 0 0 / 12%);
    padding: .84rem 2.14rem;
    font-size: .81rem;
    transition: all .2s ease-in-out;
    margin: .375rem;
    border: 0;
    border-radius: .125rem;
    cursor: pointer;
    text-transform: uppercase;
    white-space: normal;
    word-wrap: break-word;
    color: white;
}
.green-text {
    color: #4caf50!important;
}
</style>
