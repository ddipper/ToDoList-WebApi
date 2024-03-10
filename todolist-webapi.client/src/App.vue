<script>
export default {
  methods: {
  }
}
</script>

<template>
  <header>
    <router-link class="header-name" :to="{ name: 'Home' }">ToDoList</router-link>
    <div class="header-links">
      <router-link :to="{ name: 'Notes' }">Notes</router-link>
      <router-link :to="{ name: 'Login' }">Login</router-link>
      <router-link :to="{ name: 'Register' }">Register</router-link>
    </div>
  </header>
  <router-view/>
</template>

<style scoped>
  * {
      font-family: Gilroy, sans-serif;
      margin: 0;
      padding: 0;
  }
  
  header{
    position: fixed;
    top: 0;
    width: 100%;
    display: flex;
    justify-content: space-evenly;
    align-items: center;
    //background-image: linear-gradient(43deg, #4158D0 0%, #C850C0 46%, #FFCC70 100%);
    background: linear-gradient(45deg,#9e9eff, #8000ff, #fecb70);
    background-size: 300% 100%;
    animation: gradient 12s linear infinite;
    animation-direction: alternate;
  }
  
  header h3{
    color: white;
  }
  
  .header-links{
    display: flex;
    justify-content: space-around;
  }
  
  .header-links a{
    color: white;
    padding: 10px 15px;
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
