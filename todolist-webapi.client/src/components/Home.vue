<script>

</script>

<template>
  <router-view/>
  <div class="content">
    <div class="glass typewriter">
      <v-icon :icon="'mdi-text'" size="50px" color="#9e9eff" class="icon"></v-icon>
      <h1>ToDo List</h1>
      <h3>Click where <span>you want</span> to go</h3>
      <div class="links">
        <router-link :to="{ name: 'Notes' }"><v-btn rounded="lg" prepend-icon="mdi-note-multiple" variant="text" size="large">Notes</v-btn></router-link>
        <router-link :to="{ name: 'Login' }"><v-btn rounded="lg" prepend-icon="mdi-account" variant="text" size="large">Login</v-btn></router-link>
        <router-link :to="{ name: 'Register' }"><v-btn rounded="lg" prepend-icon="mdi-account-plus" variant="text" size="large">Register</v-btn></router-link>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
  .content {
    display: flex;
    padding-top: 50px;
    height: 100vh;
    background: #232323;
    align-items: center;
    justify-content: center;
  }
  .glass {
    display: flex;
    flex-direction: column;
    width: 800px;
    padding: 100px 10px;
    //background: linear-gradient(to right, #fcad7d, #DE6262); 
    justify-content: center;
    align-items: center;
    text-align: center;
    color: white;

    h3{
      font-weight: normal;
      padding: 10px 0 30px;
    }

    h3 span{
      color: #fecb70;
      font-weight: bold;
    }
  }

  .links {
    padding: 7px 0;
    width: 75%;
    display: flex;
    justify-content: space-around;
  }

  .typewriter h1 {
    color: #fff;
    overflow: hidden; 
    border-right: .15em solid #7256cb; 
    white-space: nowrap;
    letter-spacing: .15em; 
    animation:
        typing 1.5s steps(10, end),
        blink-caret .5s step-end infinite;
  }
  
  @keyframes typing {
    from { width: 0 }
    to { width: 210px; }
  }

  @keyframes blink-caret {
    from, to { border-color: transparent }
    50% { border-color: #7256cb }
  }
  
  .icon{
    margin-bottom: 10px;
  }
</style>