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
      Добавить пользователя
    </h1>
    <p>Имя</p>
    <input v-text-field v-model="name" placeholder="имя" />
    <p>Пароль</p>
    <input v-text-field v-model="password" placeholder="пароль" />
    <p>Email</p>
    <input v-text-field v-model="email" placeholder="электронная почта" />
    <p>Код</p>
    <input v-text-field v-model="code" placeholder="код" />
    <p>Адрес</p>
    <input v-text-field v-model="adress" placeholder="адрес" />
    <p>Скидка</p>
    <input v-text-field v-model="discount" placeholder="скидка" />
    <input v-text-field v-model="uuid" placeholder="скидка" />
    <div>
      .
    </div>
    <div>
      <v-btn class="green" @click="handleAddUser">Добавить пользователя</v-btn>
    </div>
  </div>

</template>
<script>
  import { uuid } from 'vue-uuid'
  export default {
    name: 'AddProductPage',
    data() {
      return {
        uuid: uuid.v1(),
        name: '',
        password: '',
        email: '',
        code: 'ХХХХ-ГГГГ',
        adress: '',
        discount: 0
      }
    },
    methods: {
      handleAddUser() {
        const newID = this.$uuid;
        fetch('http://localhost:5049/api/Users', {

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
              Id: this.newID,
              UserName: this.login,
              PasswordHash: this.password,
              Email: this.email,
            }
          )
        })
          .then(res => res.json())
          .then((result) => {
            if (result === 'Пользователь успешно создан') {
              //this.$router.push('/ProductsPage')

              fetch('http://localhost:5049/api/Clients', {

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
                    Id: this.newID,
                    Name: this.name,
                    Code: this.code,
                    Address: this.adress,
                    Discount: this.discount,
                  }
                )
              })
                .then(res => res.json())
                .then((result) => {
                  if (result === 'Клиент успешно создан') {
                    alert('Пользователь успешно создан')
                    this.$router.push('/UsersPage')

                  }
                  else {

                    var errormessage = "Неверные параметры клиента";
                    alert(errormessage);
                  }
                },
                  (error) => {
                    alert(error);
                  })

            


            }
            else {

              var errormessage = "Неверные параметры пользователя";
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
