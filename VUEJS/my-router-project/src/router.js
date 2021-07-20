import { createWebHistory, createRouter } from "vue-router";
const Index = () => import("./view/Index")
const ProductsDetails = () => import("./view/ProductsDetails")
const ListProducts = () => import("./view/ListProducts")
const Category = () => import("./view/Category")
const Blog = () => import("./view/Blog")
const routes = [
  {
    path: "/",
    name: "Home",
    component: Index,
  },
  {
    path: "/product/:id",
    name: "Product",
    component: ProductsDetails,
    props: true,
  },
  {
    path: "/listproduct/:id",
    name: "ListProducts",
    component: ListProducts,
    props: true,
  },
  {
    path: "/category/:id",
    name: "Category",
    component: Category,
    props: true,
  },
  {
    path: "/blog",
    name: "Blog",
    component: Blog,
    props: false,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;