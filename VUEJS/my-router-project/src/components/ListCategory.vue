<template>
  <section class="container-fluid">
    <div class="row">
      <div
        class="col-lg-6 col-12"
        v-for="item in article.slice(0, 1)"
        :key="item.id"
      >
        <router-link :to="{ name: 'Category', params: { id: item.id } }">
          <div class="card-a">
            <div>
              <img
                class="my-card-img"
                v-lazy="{
                  src:
                    'http://res.cloudinary.com/imageshared/image/upload/c_scale,f_auto,q_auto/v1/' +
                    item.coverImage,
                  loading: srcload,
                  error: srcerror,
                }"
              />
            </div>
          </div>

          <div class="news-data d-flex justify-content-between">
            <a href="#!" class="deep-orange-text mt-3">
              <h6 class="font-weight-bold">
                <i class="fa-utensils p-2 fas" style="marg"></i
                >{{ item.nameBlog }}
              </h6></a
            >
            <p class="fw-bold dark-grey-text mt-3">
              <i class="fa-clock p-2 far"></i
              >{{ item.createDate.substring(0, 10) }}
            </p>
          </div>
          <p class="dark-grey-text mb-lg-0 mb-md-5 mb-4">
            {{ item.titleMeta }}
          </p>
        </router-link>
      </div>
      <div class="col-lg-6 col-12">
        <div v-for="item in article.slice(1, 5)" :key="item.id">
          <div class="row">
            <!-- Grid column -->
            <div class="col-md-3">
              <!--Image-->
              <div class="view overlay rounded z-depth-1 mb-4">
                <img
                  class="my-card-img"
                  v-lazy="{
                    src:
                      'http://res.cloudinary.com/imageshared/image/upload/c_scale,f_auto,q_auto/v1/' +
                      item.coverImage,
                    loading: srcload,
                    error: srcerror,
                  }"
                />

                <a>
                  <div class="mask rgba-white-slight waves-light"></div>
                </a>
              </div>
            </div>
            <!-- Grid column -->
            <!-- Grid column -->
            <div class="col-md-9">
              <router-link :to="{ name: 'Category', params: { id: item.id } }">
                <!-- Excerpt -->
                <p class="fw-bold dark-grey-text">
                  {{ item.createDate.substring(0, 10) }}
                </p>
                <div class="d-flex justify-content-between">
                  <div class="col-11 text-truncate pl-0 mb-3">
                    <a href="#!" class="dark-grey-text">{{ item.titleMeta }}</a>
                  </div>
                  <a>
                    <i class="fas fa-angle-double-right"></i>
                  </a>
                </div>
              </router-link>
            </div>

            <!-- Grid column -->
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import srcld from "../assets/ld.gif";
import srcer from "../assets/er.jpg";
export default {
  components: {},
  props: {
    article: [],
  },
  data() {
    return {
      srcerror: srcer,
      srcload: srcld,
    };
  },
  created() {},
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

    








