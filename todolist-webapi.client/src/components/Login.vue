<template>
  <router-view/>
  <div class="content">
    <v-icon :icon="'mdi-account'" size="50px" color="#9e9eff" class="icon"></v-icon>
    <h1>Login to ToDo List</h1>
    <v-form @submit.prevent class="form" v-model="valid">
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
      <v-btn class="mt-2" type="submit" block>Login</v-btn>
    </v-form>
  </div>
</template>

<script>
export default {
  data: () => ({
    valid: false,
    username: '',
    password: '',
    email: '',
    rules: [
      value => {
        if (value) return true

        return 'This is a required field.'
      },
    ],
  }),
  
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

.icon{
  margin-bottom: 10px;
}
</style>
