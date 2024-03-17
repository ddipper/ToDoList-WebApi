<template>
  <router-view/>
  <div class="content">
    <v-btn prepend-icon="mdi-plus" variant="tonal" class="btn-create">
      New note
    </v-btn>
    <div class="note">
      <h2>Note name</h2>
      <h3>Todo Tomorrow is a note created to organize and prioritize tasks that need to be accomplished the next day. This note serves as a reminder and a planner, helping users to stay focused and efficient. It can include various tasks ranging from personal errands to professional assignments. Users can add, update, or delete tasks as their schedule changes.</h3>
      <div class="note-buttons">
        <v-btn size="small" prepend-icon="mdi-pencil">Edit note</v-btn>
        <v-btn size="small" prepend-icon="mdi-minus">Delete note</v-btn>
      </div>
    </div>
  </div>
</template>

<script>

</script>

<style lang="scss" scoped>
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

    h2 {
      font-weight: normal;
      font-size: 30px;
    }

    h3{
      font-weight: normal;
      padding-bottom: 20px;
      padding-top: 5px;
      font-size: 17px;
      text-align: justify;
    }
  }
  
  .note-buttons {
    width: 100%;
    display: flex;
    justify-content: space-evenly;

    button{
      width: 30%;
      height: 37px;
    }
  }
  
</style>