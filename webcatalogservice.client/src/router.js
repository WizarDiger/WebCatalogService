
import { createMemoryHistory, createRouter } from 'vue-router'
import LoginPage from '../views/LoginPage.vue';
import AdminPage from '../views/AdminPage.vue';
import ProductsPage from '../views/ProductsPage.vue';
import ProductDetails from '../views/ProductDetails.vue';

const routes = [
  {
    path: '/',
    component: LoginPage
  },
  {
    name: 'LoginPage',
    path: '/LoginPage',
    component: LoginPage
  },
  {
    name: 'AdminPage',
    path: '/AdminPage',
    component: AdminPage
  },
  {
    name: 'ProductsPage',
    path: '/ProductsPage',
    component: ProductsPage
  },
  {
    name: 'ProductDetails',
    path: '/ProductsPage/:id',
    component: ProductDetails,
    props: true
  },

]
const router = createRouter({
  history: createMemoryHistory(),
  routes
})
export default router
