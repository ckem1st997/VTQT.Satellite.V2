import { createApp } from 'vue'
import App from './App.vue'
import router from './router' // <---
import VueParticles from 'vue-particles'
import Vue3Progress from "vue3-progress";
import VueLazyLoad from 'vue3-lazyload'

// import Swiper styles
import 'swiper/swiper-bundle.css';
import axios from 'axios';
// axios.defaults.baseURL="http://apigate.somee.com/a/"

const app = createApp(App)
router.beforeEach(function (to, from, next) {
    window.scrollTo(0, 0);
    next();
});

app.use(router)
app.use(VueParticles)
const options = {
    position: "fixed",
    height: "3px",
    // color: "<Your Color>",
};
app.use(VueLazyLoad, {
    loading: () => {
      console.log('loading')
    },
    error: () => {
      console.log('error')
    },
    loaded: () => {
      console.log('loaded')
    }
  })

app.use(Vue3Progress, options)
app.mount('#app')
