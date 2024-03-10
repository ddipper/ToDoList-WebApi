<template>
  <router-view/>
  <div class="content">
    <v-icon :icon="'mdi-plus'" size="50px" color="#9e9eff" class="icon"></v-icon>
    <h1>Register to ToDo List</h1>
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
      <v-btn class="mt-2" type="submit" block>Register</v-btn>
    </v-form>
  </div>
</template>

<script>
export default {
  data: () => ({
    valid: false,
    username: '',
    password: '',
    password2: '',
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

<style scoped>
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
</style>
