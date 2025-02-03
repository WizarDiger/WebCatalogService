
<template>
  <div id="nav">
    <router-link to="/">LoginPage</router-link>
    <router-link :to="{name: 'LoginPage'}"> LoginPage</router-link>
    <router-link :to="{name: 'AdminPage'}"> AdminPage</router-link>
    <router-link :to="{name: 'ProductsPage'}"> ProductsPage</router-link>
  </div>
  <div>
    <h1>
      Login Page A
    </h1>
    <p>Логин</p>
    <input v-model="message" placeholder="логин" />
    <p>Пароль</p>
    <input v-model="message" placeholder="пароль" />
    <div>
      <button>Войти</button>
    </div>
  </div>
</template>
<script>
  export default {
    name:'LoginPage'
  }
</script>
