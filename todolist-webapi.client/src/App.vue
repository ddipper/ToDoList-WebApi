<script>
import { useUserStore } from "@/stores/UserStore.js";
export default {
  data() {
    return {
      userStore: useUserStore(),  
    }
  },
  methods: {
    logOut(){
      this.userStore.setUsername(null);
    }
  }
}
</script>

<template>
  <header>
    <router-link class="header-name" :to="{ name: 'Home' }">ToDoList</router-link>
    <div class="header-links">
      <router-link :to="{ name: 'Notes' }">Notes</router-link>
      <router-link v-if="userStore.username == null" :to="{ name: 'Login' }">Login</router-link>
      <router-link v-if="userStore.username == null" :to="{ name: 'Register' }">Register</router-link>
      <h2 v-if="userStore.username != null">{{ userStore.username }}</h2>
      <h3 v-if="userStore.username != null" @click="logOut()">Logout</h3>
    </div>
  </header>
  <router-view/>
</template>

<style lang="scss" scoped>
  * {
      font-family: Gilroy, sans-serif;
      margin: 0;
      padding: 0;
  }
  
  header{
    z-index: 1;
    position: fixed;
    top: 0;
    width: 100%;
    display: flex;
    justify-content: space-evenly;
    align-items: center;
    background: linear-gradient(45deg,#9e9eff, #8000ff, #fecb70);
    background-size: 300% 100%;
    animation: gradient 12s linear infinite;
    animation-direction: alternate;

    h3{
      color: white;
    }
    
  }
  
  .header-links{
    display: flex;
    justify-content: space-around;
    
    a{
      color: white;
      padding: 10px 15px;
    }
    
    h2 {
      color: white;
      padding: 10px 15px;
      font-size: 15px;
    }

    h3{
      text-decoration: underline;
      font-size: 14px;
      padding: 10px 15px;
      font-weight: 400;
      text-align: center;
      align-items: center;
    }
  }
  
  .header-name{
    color: white;
    font-size: 20px;
    text-decoration: none;
    font-weight: bold;
  }
  
  a{
    color: red;
  }

  @keyframes gradient {
    0% {background-position: 0%}
    100% {background-position: 100%}
  }
  
</style>
