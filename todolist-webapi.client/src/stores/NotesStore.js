import { defineStore } from 'pinia'

export const useNotesStore = defineStore("notesStore", {
    state: () => ({
        notes: [
            {
                Title: 'ToDo tomorrow',
                Description: 'Todo Tomorrow is a note created to organize and prioritize tasks that need to be accomplished the next day. This note serves as a reminder and a planner, helping users to stay focused and efficient. It can include various tasks ranging from personal errands to professional assignments. Users can add, update, or delete tasks as their schedule changes.'
            },
            {
                Title: '123TITLE',
                Description: '123Description',
            }
        ]
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
            const note = this.findNote(oldTitle, oldDescription);
            if (note) {
                note.Title = newTitle;
                note.Description = newDescription;
            }
        }
    },
})