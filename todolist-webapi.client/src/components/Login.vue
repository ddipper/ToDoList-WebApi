<template>
  <header></header>
  <div class="login">
    <h2>Login</h2>
    <form @submit.prevent="submitForm">
      <label for="username">Username:</label>
      <input type="text" id="username" v-model="username" />

      <label for="password">Password:</label>
      <input type="password" id="password" v-model="password" />

      <button type="submit">Login</button>
    </form>
  </div>
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
.login {
  width: 300px;
  margin: 0 auto;
}
</style>
