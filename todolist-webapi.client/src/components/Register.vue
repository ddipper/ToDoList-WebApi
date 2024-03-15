<template>
  <router-view/>
  <div class="content">
    <v-icon :icon="'mdi-plus'" size="50px" color="#9e9eff" class="icon" v-if="!user"></v-icon>
    <h1 v-if="!user">Register to ToDo List</h1>
    <v-form @submit.prevent class="form" v-if="!user" @submit="register()">
      <v-text-field
          v-model="username"
          label="Username"
          :rules="rules"
          required
      ></v-text-field>
      <v-text-field
          v-model="password"
          label="Password"
          :rules="rules"
          required
      ></v-text-field>
      <v-text-field
          v-model="password2"
          label="Repeat password"
          type="password"
          :rules="rules"
          required
      ></v-text-field>
      <v-btn class="mt-2" type="submit" block >Register</v-btn>
    </v-form>
    <div v-else class="form">
      <h1>You are registered. Username: {{ username }}</h1>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  data() {
    return {
      API_URL: 'http://localhost:5106',
      
      username: '',
      password: '',
      password2: '',
      rules: [
        value => {
          if (value) return true

          return 'This is a required field.'
        },
      ],
      user: null,
    }
  },
  methods: {
    async register() {
      await axios.post(
          `${this.API_URL}/register`, { username: this.username, password: this.password },
          { headers: { 'Content-Type': 'application/json' } }
      ).then(({ data }) => {
        if(data.error == '0') {
          this.user = data.username;
        }
        else {
          alert('This username already taken.');
        }

        
      })
    }
  }

}
</script>

<style scoped>
.content{
  height: 100vh;
  background: #232323;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}

.content h1{
  margin-bottom: 40px;
}

.form{
  width: 350px;
}

.icon{
  margin-bottom: 10px;
}

.form h1{
  text-align: center;
}

</style>