<template>
  <header>
    <h3>ToDoList</h3>
    <div class="header-links">
      <a>Link</a>
      <a>Link</a>
      <a>Link</a>
    </div>
  </header>
  <div class="content">
    
  </div>
</template>

<script>

</script>

<style scoped>
  * {
    font-family: Gilroy, sans-serif;
  }
  
  header{
    position: fixed;
    top: 0;
    width: 100%;
    display: flex;
    justify-content: space-evenly;
    align-items: center;
    background-color: #4158D0;
    background-image: linear-gradient(43deg, #4158D0 0%, #C850C0 46%, #FFCC70 100%);

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
  
</style>
