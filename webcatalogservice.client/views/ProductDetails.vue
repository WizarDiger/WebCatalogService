
<template>
  <div id="nav">
    <router-link to="/">LoginPage</router-link>
    <router-link :to="{name: 'LoginPage'}"> LoginPage</router-link>
    <router-link :to="{name: 'AdminPage'}"> AdminPage</router-link>
    <router-link :to="{name: 'ProductsPage'}"> ProductsPage</router-link>
  </div>
  <h1>
    Информация о товаре
  </h1>
  <p>Код товара: {{$route.params.id}}</p>
  <p>Наименование: {{name}}</p>
  <p>Цена: {{price}}</p>
  <p>Категория: {{category}}</p>
  <p></p>

</template>
<script>
  export default {
    props:['id'],
   // data() {
     // return {
       // id: this.$route.params.id
      //}
    //}
  }
</script>
