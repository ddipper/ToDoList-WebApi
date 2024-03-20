import { defineStore } from 'pinia'

export const useNotesStore = defineStore("notesStore", {
    state: () => ({
        notes: []
    }),
    actions: {
        deleteNote(title, description) {
            const index = this.notes.findIndex(note => note.Title === title && note.Description === description);
            if (index !== -1) {
                this.notes.splice(index, 1);
            }
        },
        addNote(title, description) {
            this.notes.push({ Title: title, Description: description });
        },
        updateNote(oldTitle, oldDescription, newTitle, newDescription) {
            const note = this.notes.find(note => note.Title === oldTitle && note.Description === oldDescription);
            if (note) {
                note.Title = newTitle;
                note.Description = newDescription;
            }
        }   
    },
})