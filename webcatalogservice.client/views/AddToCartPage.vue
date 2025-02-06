<script setup>
  import Grid from '../src/components/Grid.vue'
  import { ref } from 'vue'
  const searchQuery = ref('')
  const gridColumns = ['Code', 'Name', 'Price', 'Category']
  const user = [];
  const userName = '';

</script>
<template>
  <div :style="{ position:'fixed',left:'0', top:'0',width:'100%', 'border-style':'solid', 'border-color':'dodgerblue', height:'20%'}">
    <div id="nav" :style="{position:'fixed', top:'5%', left:'1%'}">
      <router-link :to="{name: 'OrdersPage'}"> Заказы</router-link>
      <router-link :to="{name: 'ProductsPage'}"> Товары</router-link>
      <router-link :to="{name: 'UsersPage'}"> Пользователи</router-link>
    </div>
  </div>
  <div :style="{position:'fixed',left:'0', top:'10%',width:'80%', padding: '1% 1% 1% 1%','border-style':'solid','border-color':'dodgerblue', height:'10%', 'border-right-width':'0px'}">
    <v-btn class="green" @click="handleAddProduct">Добавить товар</v-btn>
    <v-btn class="green" @click="handleAddUser">Добавить пользователя</v-btn>
    <v-btn class="green" @click="handleAddUser">Добавить заказ</v-btn>
    <v-btn class="green" @click="handleAddProduct">Редактировать товар</v-btn>
    <v-btn class="green" @click="handleAddUser">Редактировать пользователя</v-btn>
    <v-btn class="green" @click="handleAddUser">Редактировать заказ</v-btn>
    <v-btn class="green" @click="handleDeleteProduct">Удалить товар</v-btn>
    <v-btn class="green" @click="handleDeleteProduct">Удалить пользователя</v-btn>
    <v-btn class="green" @click="handleDeleteProduct">Удалить заказ</v-btn>
  </div>
  <div :style="{ position:'fixed', top:'0',left:'80%',width:'20%', padding: '10px 10px 10px 10px', height:'20%', 'border-style':'solid', 'border-color':'dodgerblue'}">
    Пользователь:
    <div :style="{padding: '10px 10px 10px 10px','border-style':'solid', width:'95%', 'border-color':'dodgerblue', height:'50%'}">
      Список ролей пользователя
    </div>
  </div>
  <div>

    <h1>
      Товары
    </h1>
    <form id="search">
      Search <input name="query" v-model="searchQuery">
    </form>
    <Grid :data="gridData"
          :columns="gridColumns"
          :filter-key="searchQuery">
    </Grid>
  </div>
</template>
<script>

  export default {
    data() {
      return {
        gridData: []
      }
    },
    name: 'ProductsPage',
    methods: {
      handleAddProduct() {
        this.$router.push('/AddProductPage')
      },
        handleAddUser() {
        this.$router.push('/AddUserPage')
      }
    },
    mounted() {
      fetch('http://localhost:5049/api/Products')
        .then(res => res.json())
        .then(data => this.gridData = data)
        .then(gridColumns => this.gridColumns = data[0])
        .catch(err => console.log(err.message))

      fetch('http://localhost:5049/api/Users')
        .then(res => res.json())
        .then(data => this.user = data)
        .catch(err => console.log(err.message))

      fetch('http://localhost:5049/api/CurrentUser')
        .then(res => res.json())
        .then(data => this.userName = data)
        .catch(err => console.log(err.message))
    }
  }
</script>
