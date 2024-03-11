<template>
  <router-view/>
  <div class="content">
    <v-btn prepend-icon="mdi-plus" variant="tonal" class="btn-create">
      New note
    </v-btn>
    <div class="note">
      <h2>Note name</h2>
      <h3>lorem ipsum oto de lato</h3>
      <div class="note-buttons">
        <v-btn size="small" prepend-icon="mdi-pencil">Edit note</v-btn>
        <v-btn size="small" prepend-icon="mdi-minus">Delete note</v-btn>
      </div>
    </div>
  </div>
</template>

<script>

</script>

<style scoped>
  .content{
    min-height: 100vh;
    background: #232323;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    gap: 50px;
  }
  
  .btn-create{
    margin-top: 50px;
  }
  
  .note{
    width: 600px;
    background: #363636;
    padding: 15px;
    display: flex;
    flex-direction: column;
  }

  .note h2 {
    font-weight: normal;
  }
  
  .note h3{
    font-weight: normal;
    padding-bottom: 20px;
    padding-top: 5px;
  }
  
  .note-buttons {
    width: 100%;
    display: flex;
    justify-content: space-evenly;
  }
  
  .note-buttons button{
    width: 30%;
    height: 37px;
  }
  
</style>