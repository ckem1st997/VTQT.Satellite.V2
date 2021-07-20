<template>
  <vue-particles
    color="#dedede"
    :particleOpacity="0.7"
    :particlesNumber="80"
    shapeType="circle"
    :particleSize="4"
    linesColor="#dedede"
    :linesWidth="1"
    :lineLinked="true"
    :lineOpacity="0.4"
    :linesDistance="150"
    :moveSpeed="3"
    :hoverEffect="true"
    hoverMode="grab"
    :clickEffect="true"
    clickMode="push"
  >
  </vue-particles>

  <!-- App.vue -->
  <Header msg="Hello" />
  <vue3-progress />
  <router-view :key="$route.fullPath"></router-view>
  <Footer />
  <!-- <Skeleton /> -->
  <ScrollTop />
</template>

<script>
import Header from "./layout/Header.vue";
import Footer from "./layout/Footer.vue";
import ProductService from "./service/Products";
export default {
  name: "App",

  components: {
    Header,
    Footer
  },

  data: () => ({
    //products: null,
  }),
  productService: null,
  created() {
   // this.productService = new ProductService();
    // this.$progress.start();

    this.$router.beforeEach((to, from, next) => {
      this.$progress.start();

      next();
    });

    this.$router.afterEach((to, from) => {
      this.$progress.finish();
     
    });
  },
  mounted() {
   // this.productService.getProducts().then((data) => (this.products = data));
    // this.$progress.finish();
    // console.log(1)
  },
  watch: {
    $route(to, from) {
      // this.$progress.finish();
    },
  },
};
</script>
<style lang="scss" scoped>
@import url("https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap");

.custom-skeleton {
  border: 1px solid var(--surface-d);
  border-radius: 4px;

  ul {
    list-style: none;
  }
}
#app {
  font-family: Roboto, Helvetica, Arial, sans-serif;
}
div.spinner-border.active {
  display: block;
}
div.spinner-border {
  display: none;
}

#particles-js {
  //  background-image: url(/static/img/sky.871d198.jpg);
  background-size: cover;
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  z-index: -1;
}
canvas {
  display: block;
}
</style>
