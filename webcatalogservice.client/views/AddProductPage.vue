
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
    <p>Код</p>
    <input v-text-field v-model="code" placeholder="код" />
    <p>Наименование</p>
    <input v-text-field v-model="name" placeholder="наименование" />
    <p>Цена</p>
    <input v-text-field v-model="price" placeholder="цена" />
    <p>Категория</p>
    <input v-text-field v-model="category" placeholder="категория" />
    <div>
      .
    </div>
    <div>
      <v-btn class="green" @click="handleSubmit">Добавить товар</v-btn>
    </div>
  </div>

</template>
<script>
  export default {
    name: 'AddProductPage',
    data() {
      return {
        code: 'XX-XXXX-YYXX',
        name: '',
        price: 0,
        category: ''
      }
    },
    methods: {
      handleSubmit() {

        fetch('http://localhost:5049/api/Products', {

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
              Code: this.code,
              Name: this.name,
              Price: this.price,
              Category: this.category,
            }
          )
        })
          .then(res => res.json())
          .then((result) => {
            if (result === 'Товар успешно добавлен') {
              this.$router.push('/ProductsPage')

            }
            else {

              var errormessage = "Неверные параметры товара";
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
