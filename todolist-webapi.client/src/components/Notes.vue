<template>
  <router-view/>
  <div class="content">
    <v-btn prepend-icon="mdi-plus" variant="tonal" class="btn-create" @click="dialogNew = true">
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
    <div class="pa-4 text-center">
      <v-dialog v-model="dialogNew" max-width="600">
        <v-card prepend-icon="mdi-plus" title="New note">
          <v-card-text>
            <v-row dense>  
              <v-col>
                <v-text-field label="Title" required></v-text-field>
              </v-col>
            </v-row>
            <v-row dense>
              <v-col>
                <v-textarea label="Description" required></v-textarea>
              </v-col>
            </v-row>
          </v-card-text>
  
          <v-divider></v-divider>
  
          <v-card-actions>
            <v-spacer></v-spacer>
  
            <v-btn text="Close" variant="plain" @click="dialogNew = false"></v-btn>
  
            <v-btn color="primary" text="Save" variant="tonal" @click="dialogNew = false" ></v-btn>
          
          </v-card-actions>
        </v-card>
      </v-dialog>
    </div>
  </div>
</template>
  
<script>
  export default {
    data: () => ({
      dialogNew: false,
    }),
  }
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