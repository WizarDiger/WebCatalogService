
import { createMemoryHistory, createRouter } from 'vue-router'
import LoginPage from '../views/LoginPage.vue';
import ProductsPage from '../views/ProductsPage.vue';
import AddProductPage from '../views/AddProductPage.vue';
import OrdersPage from '../views/OrdersPage.vue';
import AddUserPage from '../views/AddUserPage.vue';
import UsersPage from '../views/UsersPage.vue';

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
    name: 'ProductsPage',
    path: '/ProductsPage',
    component: ProductsPage
  },
  {
    name: 'AddProductPage',
    path: '/AddProductPage',
    component: AddProductPage
  },
  {
    name: 'AddUserPage',
    path: '/AddUserPage',
    component: AddUserPage
  },
  {
    name: 'OrdersPage',
    path: '/OrdersPage',
    component: OrdersPage
  },
  {
    name: 'UsersPage',
    path: '/UsersPage',
    component: UsersPage
  },


]
const router = createRouter({
  history: createMemoryHistory(),
  routes
})
export default router
