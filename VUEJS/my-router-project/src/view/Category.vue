<template>
  <div class="row breadcrumb-shop">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pd5">
      <ol class="breadcrumb breadcrumb-arrows">
        <li><router-link to="/">Trang chủ</router-link></li>
        <li>
          <router-link to="/blog">Bài viết</router-link>
        </li>
        <li class="active">
          <span> {{article.description}}</span>
        </li>
      </ol>
    </div>
  </div>

  <div id="reviewblog" class="ReviewDetail-page">
    <input type="hidden" id="rvInfo" value="" />
    <div class="container-fluid" v-if="article != null">
      <div class="row review-detail-wrapper">
        <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12 review-detail-post">
          <div class="review-detail-post-title mb-4">
            <div class="post-title wow animate__fadeInLeftBig">
              {{ article.subject }}
            </div>
            <div
              class="post-info text-center mt-2 wow animate__fadeInUpBig"
              data-wow-duration="1.5s"
              data-wow-delay="0.5s"
            >
              <span class="by">By Admin on </span>
              <i class="far fa-window-minimize ml-2"></i>
              <span class="date">
                {{ article.createDate.substring(0, 10) }}</span
              >
              <span class="view">
                <i class="far fa-eye"></i> 1{{ article.view }} Views</span
              >
              <span class="cmt"
                ><i class="far fa-comments"></i> 22 Bình luận</span
              >
            </div>
          </div>
          <div class="review-blog" v-html="article.body"></div>
          <div class="share-social text-center">
            <span class="font-weight-bold"> Share: &nbsp;</span>
            <i class="fab fa-facebook-f me-3"></i>
            <i class="fab fa-twitter me-3"></i>
            <i class="fab fa-google-plus-g"></i>
          </div>
        </div>
        <div
          class="
            col-lg-3 col-md-12 col-sm-12 col-xs-12
            review-detail-latest review-detail-post
          "
        >
          <div class="post-title w-100 mb-5">BÀI VIẾT</div>

          <div
            class="review-detail-latest-content"
            v-for="item in listarticle"
            :key="item"
          >
            <router-link
              :to="{
                name: 'Category',
                params: { id: item.id },
              }"
            >
              <div class="d-flex justify-content-between">
                <img
                  :src="
                    'http://res.cloudinary.com/imageshared/image/upload/c_scale,h_100,w_224/v1/' +
                    item.coverImage
                  "
                />
                <div class="">
                  <div class="title-main test2 mb-3 ms-2 font-weight-bold">
                    {{ item.description }}
                  </div>
                  <span class="date-info font-weight-bold ml-2">{{
                    item.createDate.substring(0, 10)
                  }}</span>
                </div>
              </div>
            </router-link>
          </div>
          <div class="post-title w-100 mb-3 text-left">Từ khóa</div>
          <div class="key-word container p-0">
            <div class="row">
              <div class="col-8">
                <label
                  class="mb-1 me-1"
                  v-for="item in article.keyWord.split(',')"
                  :key="item"
                >
                  {{ item }}
                </label>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import HomeService from "../service/Home";
import { useRoute } from "vue-router";
export default {
  components: {},
  data: () => ({ article: null, listarticle: [] }),
  homeService: null,
  async created() {
    this.homeService = new HomeService();
    const route = useRoute();
    await this.homeService.getArticle(route.params.id).then((data) => {
      this.article = data;
    });
  },
  async mounted() {
    const route = useRoute();
    await this.homeService.getListArticleId(route.params.id).then((data) => {
      this.listarticle = data;
    });
  }
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
#reviewblog .review-detail-wrapper {
  border-bottom: 1px solid #333333;
}
#reviewblog
  .review-detail-wrapper
  .review-detail-post
  .review-detail-post-title
  .post-info
  i.fa-window-minimize {
  transform: rotate(90deg);
  color: #c4c4c4;
}
#reviewblog
  .review-detail-wrapper
  .review-detail-post
  .review-detail-post-title
  .post-info
  .by {
  font-family: Roboto;
  font-style: normal;
  font-weight: 900;
  line-height: 142.68%;
  /* or 43px */
  text-align: center;
  letter-spacing: 0.015em;
  /* dark grey */
  color: #3f3f3f;
}
#reviewblog
  .review-detail-wrapper
  .review-detail-post
  .review-detail-post-title
  .post-info
  span
  i {
  padding-left: 5px;
  margin-left: 10px;
  color: #2c83d8;
}
#reviewblog .review-detail-wrapper .review-detail-post .main-bold {
  padding: 25px;
  font-weight: bold;
  margin: 27px;
  border-left: 6px solid #c4c4c4;
}
#reviewblog .review-detail-wrapper .review-detail-post .share-social {
  font-size: 19px;
  margin-bottom: 29px;
}
#reviewblog .review-detail-wrapper .review-detail-latest .latest-title {
  font-family: Roboto;
  font-style: normal;
  font-weight: 900;
  font-size: 30px;
  line-height: 142.68%;
  /* or 43px */
  text-align: center;
  letter-spacing: 0.015em;
  /* dark grey */
  color: #3f3f3f;
  margin-bottom: 41px;
}
#reviewblog .review-detail-wrapper .review-detail-latest-content {
  margin-bottom: 47px;
  border-bottom: 1px solid #000000;
  padding: -7px;
  padding-bottom: 45px;
  transition: all 0.4s ease;
}
#reviewblog .review-detail-wrapper .review-detail-latest-content img {
  height: 78px;
}
#reviewblog .review-detail-wrapper .review-detail-latest-content div span {
  letter-spacing: 0;
}
#reviewblog .review-detail-wrapper .review-detail-latest-content:hover {
  transform: translateY(-10px);
}
#reviewblog
  .review-detail-wrapper
  .review-detail-latest-content:hover
  div
  span {
  color: #48cab2;
}
#reviewblog .review-detail-wrapper .key-word label {
  transition: all 0.4s ease;
  border: 1px solid;
  border-radius: 5px;
  padding: 10px;
  padding-right: 18px;
  padding-left: 18px;
}
#reviewblog .review-detail-wrapper .key-word label:hover {
  transform: translateY(-5px);
  background-color: orangered;
  color: white;
}
.date-info {
  font-family: Roboto;
  font-style: italic;
  font-weight: normal;
  font-size: 16px;
  line-height: 142.68%;
  letter-spacing: 0.015em;
  color: #3f3f3f;
}
.post-title {
  font-family: Roboto;
  font-style: normal;
  font-weight: 900;
  font-size: 30px;
  line-height: 142.68%;
  text-align: center;
  letter-spacing: 0.015em;
  color: #3f3f3f;
}
img {
  max-width: 100% !important;
}
.review-blog img {
  max-width: 100% !important;
}
</style>