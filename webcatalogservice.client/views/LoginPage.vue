
<template>
  <div id="nav">
    <router-link to="/">LoginPage</router-link>

    <router-link :to="{name: 'OrdersPage'}"> Заказы</router-link>
    <router-link :to="{name: 'ProductsPage'}"> Товары</router-link>
  </div>
  <div>
    <h1>
      Login Page
    </h1>
    <p>Логин</p>
    <input v-text-field v-model="login" placeholder="логин" />
    <p>Пароль</p>
    <input v-text-field v-model="password" placeholder="пароль" />
    <div>
      <v-btn @click="handleSubmit">Войти</v-btn>
    </div>
    <p>value: {{login}}</p>
  </div>
</template>

<script>
  export default {
    name: 'LoginPage',
    data() {
      return {
        login: '',
        password:''
      }
    },
    methods: {
      handleSubmit() {

        fetch('http://localhost:5049/api/Login', {

          method: 'POST',
          credentials: 'include',
          headers:
          {
            'Access-Control-Allow-Origin': 'https://localhost:49470',
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(
            {
              UserName: this.login,
              PasswordHash: this.password,
              Email: "",
            }
          )
        })
          .then(res => res.json())
          .then((result) => {
            if (result === 'Пользователь успешно авторизован') {
              this.$router.push('/ProductsPage')

            }
            else {

              var errormessage = "Неправильный логин и/или пароль";
              alert(errormessage);
            }
          },
            (error) => {
              alert(error);
            })

      }
    }
  }
</script>

