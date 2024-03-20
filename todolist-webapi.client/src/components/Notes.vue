<template>
  <router-view/>
  <div class="content">
    <v-btn prepend-icon="mdi-plus" variant="tonal" class="btn-create" @click="dialogNew = true">
      New note
    </v-btn>
    <div class="note" v-for="note in notesStore.notes">
      <h2>{{ note.Title }}</h2>
      <h3>{{ note.Description }}</h3>
      <div class="note-buttons">
        <v-btn size="small" prepend-icon="mdi-pencil" @click="openEditDialog(note)">Edit note</v-btn>
        <v-btn size="small" prepend-icon="mdi-minus" @click="deleteNote(note.Title, note.Description)">Delete note</v-btn>
      </div>
    </div>
    
    <!--New note dialog-->
    <div class="pa-4 text-center">
      <v-dialog v-model="dialogNew" max-width="600">
        <v-card prepend-icon="mdi-plus" title="New note">
          <v-card-text>
            <v-row dense>  
              <v-col>
                <v-text-field label="Title" required v-model="noteTitle" :rules="rules"></v-text-field>
              </v-col>
            </v-row>
            <v-row dense>
              <v-col>
                <v-textarea label="Description" required v-model="noteDescription" :rules="rules"></v-textarea>
              </v-col>
            </v-row>
          </v-card-text>
  
          <v-divider></v-divider>
  
          <v-card-actions>
            <v-spacer></v-spacer>
  
            <v-btn text="Close" variant="plain" @click="dialogNew = false" :loading="loading"></v-btn>
  
            <v-btn color="primary" text="Add note" variant="tonal" @click="newNote()" :loading="loading"></v-btn>
          
          </v-card-actions>
        </v-card>
      </v-dialog>
    </div>
    
    <!--Edit note dialog-->
    <div class="pa-4 text-center">
      <v-dialog v-model="dialogEdit" max-width="600">
        <v-card prepend-icon="mdi-pencil" title="Edit note">
          <v-card-text>
            <v-row dense>
              <v-col>
                <v-text-field label="Title" required v-model="editTitle" :rules="rules" ></v-text-field>
              </v-col>
            </v-row>
            <v-row dense>
              <v-col>
                <v-textarea label="Description" required v-model="editDescription" :rules="rules"></v-textarea>
              </v-col>
            </v-row>
          </v-card-text>

          <v-divider></v-divider>

          <v-card-actions>
            <v-spacer></v-spacer>

            <v-btn text="Close" variant="plain" @click="dialogEdit = false" :loading="loading"></v-btn>

            <v-btn color="primary" text="Edit note" variant="tonal" @click="newNote()" :loading="loading"></v-btn>

          </v-card-actions>
        </v-card>
      </v-dialog>
    </div>
  </div>
</template>
  
<script setup>
  import axios from 'axios'
  import { useUserStore } from "@/stores/UserStore.js";
  import { useNotesStore } from "@/stores/NotesStore.js";
  
  axios.post(
      `http://localhost:5106/notes`, { username: useUserStore().username, title: 'none', description: 'none' },
      { headers: { 'Content-Type': 'application/json' } }
  ).then( (response) => {
    const data = response.data;
    if(data.notes != null || response.status != 200) {
      for (const note of data.notes) {
        useNotesStore().addNote(note.title, note.description);
      }
    }
  })
</script>

<script>
import axios from 'axios'
import { useUserStore } from "@/stores/UserStore.js";
import { useNotesStore } from "@/stores/NotesStore.js";
export default {
    data: () => ({
      API_URL: 'http://localhost:5106',
      notesStore: useNotesStore(),
      userStore: useUserStore(),
      dialogNew: false,
      dialogEdit: false,
      noteTitle: '',
      noteDescription: '',
      editTitle: '',
      editDescription: '',
      rules: [
        value => {
          if (value) { return true }
          return 'This is a required field.'
        },
      ],
      loading: false,
    }),
    methods: {
      load () {
        this.loading = true
      },
      unLoad() {
        this.loading = false
      },
      async newNote() {
        this.dialogNew = false;
        if(this.noteTitle == '' || this.noteDescription == '') 
        {
          alert('Title or description fields are not filled in.')
          return
        }
        this.load()
        await axios.post(
            `${this.API_URL}/notes/add`, { username: this.userStore.username, title: this.noteTitle, description: this.noteDescription },
            { headers: { 'Content-Type': 'application/json' } }
        ).then(({ data }) => {
          this.unLoad();
          this.notesStore.addNote(this.noteTitle, this.noteDescription);
          this.noteTitle = '';
          this.noteDescription = '';
        })
      },
      async deleteNote(title, description){
        await axios.post(
            `${this.API_URL}/notes/delete`, { username: this.userStore.username, title: title, description: description },
            { headers: { 'Content-Type': 'application/json' } }
        ).then(({ data }) => {
          this.notesStore.deleteNote(title, description);
        })
      },
      async editNote(oldTitle, oldDescription, newTitle, newDescription) {
        if(this.noteTitle == '' || this.noteDescription == '')
        {
          alert('Title or description fields are not filled in.')
          return
        }
        this.load()
        await axios.post(
            `${this.API_URL}/notes/edit`, { username: this.userStore.username, title: oldTitle, description: oldDescription, newTitle: newTitle, newDescription },
            { headers: { 'Content-Type': 'application/json' } }
        ).then(({ data }) => {
          this.unLoad();
          this.notesStore.updateNote(oldTitle, oldDescription, newTitle, newDescription);
          this.dialogEdit = false;
        })
      },
      openEditDialog(note) {
        this.editTitle = note.Title;
        this.editDescription = note.Description;
        this.dialogEdit = true;
      },
    }
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
    margin-top: 75px;
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