<template>
  <router-view/>
  <div class="content">
    <v-icon v-if="userStore.username == null" :icon="'mdi-account'" size="50px" color="#9e9eff" class="icon"></v-icon>
    <h1 v-if="userStore.username == null">Login to ToDo List</h1>
    <v-form v-if="userStore.username == null" @submit.prevent class="form" @submit="login()">
      <v-text-field
          v-model="username"
          label="Username"
          :rules="rules"
          required
      ></v-text-field>
      <v-text-field
          v-model="password"
          label="Password"
          type="password"
          :rules="rules"
          required
      ></v-text-field>
      <v-btn class="mt-2" type="submit" block :loading="loading" :active="btnSubmit">Login</v-btn>
    </v-form>
    <div v-else class="form2">
      <h1>You have been successfully logged.<br>Username: {{ userStore.username }}</h1>
      <router-link :to="{ name: 'Notes' }">Go to notes</router-link>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import { useUserStore } from "@/stores/UserStore.js";

export default {
  data: () => ({
    userStore: useUserStore(),
    API_URL: 'http://localhost:5106',
    username: '',
    password: '',
    rules: [
      value => {
        if (value) { return true }
        return 'This is a required field.'
        if (this.password != null && this.username != null) { this.btnSubmit = true }
      },
    ],
    loading: false,
    btnSubmit: false,
  }),
  methods: {
    async login() {
      if(this.username == null || this.password == null)
      {
        alert('Check the correctness of the entered data.')
        return
      }
      this.load()
      await axios.post(
          `${this.API_URL}/login`, { username: this.username, password: this.password },
          { headers: { 'Content-Type': 'application/json' } }
      ).then(({ data }) => {
        if(data.error == null) {
          this.userStore.setUsername(data.username);
        }
        else if (data.error == 'unregister'){
          alert('Check the correctness of the entered data');
          this.unLoad()
        }
      })
    },
    load () {
      this.loading = true
    },
    unLoad() {
      this.loading = false
    }
  }
}
</script>

<style lang="scss" scoped>
body {
  width: 300px;
  margin: 0 auto;
  background: olive;
}

.content{
  height: 100vh;
  background: #232323;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;

  h1{
    margin-bottom: 40px;
  }
}

.form{
  width: 350px;
}

.form2{
  width: 100%;
  align-items: center;
  display: flex;
  flex-direction: column;

  h1 {
    width: 100%;
    text-align: center;
  }

  a{
    text-align: center;
    width: 100%;
    color: white;
    font-size: 20px;
  }
}

.icon{
  margin-bottom: 10px;
}
</style>
