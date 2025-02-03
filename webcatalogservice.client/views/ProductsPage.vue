<script setup>
  import Grid from '../src/components/Grid.vue'
  import { ref } from 'vue'

  const searchQuery = ref('')
  const gridColumns = ['Code', 'Name', 'Price', 'Category']

</script>
<template>
  <div id="nav">
    <router-link to="/">LoginPage</router-link>
    <router-link :to="{name: 'LoginPage'}"> LoginPage</router-link>
    <router-link :to="{name: 'AdminPage'}"> AdminPage</router-link>
    <router-link :to="{name: 'ProductsPage'}"> ProductsPage</router-link>
  </div>
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
</template>
<script>

  export default {
    data() {
      return {
        gridData:[]
      }
    },
    name: 'ProductsPage',
    mounted() {
      fetch('http://localhost:5049/api/Products')
        .then(res => res.json())
        .then(data => this.gridData = data)
        .then(gridColumns => this.gridColumns = data[0])
        .catch(err => console.log(err.message))
    }
  }
</script>
