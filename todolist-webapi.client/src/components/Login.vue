<template>
  <router-view/>
    <h2>Login</h2>
    <form @submit.prevent="submitForm">
      <label>Username:</label>
      <input type="text" v-model="username" />

      <label>Password:</label>
      <input type="password" v-model="password" />

      <button type="submit" @click="submitForm()">Login</button>
    </form>
  
</template>

<script>
export default {
  data() {
    return {
      username: '',
      password: ''
    }
  },
  methods: {
    submitForm() {
      console.log('Username:', this.username);
      console.log('Password:', this.password);
    }
  }
}
</script>

<style scoped>
body {
  width: 300px;
  margin: 0 auto;
  background: olive;
}
</style>
