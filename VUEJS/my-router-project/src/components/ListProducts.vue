<template>
  <div class="container-fluid d-flex justify-content-center">
    <div class="row">
      <div
        class="col-12 col-sm-6 col-md-4 col-lg-3 mt-3"
        v-for="item in products"
        :key="item.productId"
      >
        <div class="my-card" style="position: relative">
          <router-link
            :to="{ name: 'Product', params: { id: item.productId } }"
          >
            <img
              class="my-card-img"
              v-lazy="{
                src:
                  'http://res.cloudinary.com/imageshared/image/upload/c_scale,f_auto,h_457,q_auto,w_457/v1/' +
                  getImage(item.image),
                loading: srcload,
                error: srcerror,
              }"
            />

            <span class="card-new badge bg-primary">NEW</span>
            <span v-if="item.saleOff > 0" class="card-sale badge bg-danger"
              >-{{ 100 - CeilPrice(item.saleOff, item.price) }}%</span
            >
            <!-- <img src="http://res.cloudinary.com/imageshared/image/upload/f_auto,q_auto/v1/{{imgpc}}"> -->

            <div class="my-card-body trainer-card-body text-center">
              <h6>{{ item.name }}</h6>
              <!-- <p>{{ item.description }}</p> -->
              <div
                class="price-products d-flex justify-content-between mt-2 mb-3"
              >
                <div v-if="item.saleOff > 0" class="text-danger fw-bold">
                  {{ item.saleOff }}$
                </div>
                <del v-if="item.saleOff > 0" class="grey-text"
                  >{{ item.price }}$</del
                >
                <div v-else class="text-danger fw-bold">{{ item.price }}$</div>
              </div>
              <hr class="grey-text" />
              <div class="pb-1 icon-list d-flex justify-content-around mb-3">
                <a
                  data-bs-toggle="tooltip"
                  data-bs-placement="top"
                  title="Chia sẻ"
                >
                  <i class="far grey-text fa-share-square"></i>
                </a>
                <a
                  data-bs-toggle="tooltip"
                  data-bs-placement="top"
                  title="Mua ngay"
                >
                  <i class="fas grey-text fa-shopping-cart"></i>
                </a>
                <a
                  data-bs-toggle="tooltip"
                  data-bs-placement="top"
                  title="Yêu thích"
                >
                  <i class="fas fa-heart" style="color: red"></i>
                </a>
              </div>
            </div>
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {};
  },
  props: {
    products: [],
  },
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

    
