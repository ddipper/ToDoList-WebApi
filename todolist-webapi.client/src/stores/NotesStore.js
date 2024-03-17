import { defineStore } from 'pinia'

export const useUserStore = defineStore("userStore", {
    state: () => ({
        notes: [
            {
                id: 1, 
                Title: 'ToDo tomorrow',
                Description: 'Todo Tomorrow is a note created to organize and prioritize tasks that need to be accomplished the next day. This note serves as a reminder and a planner, helping users to stay focused and efficient. It can include various tasks ranging from personal errands to professional assignments. Users can add, update, or delete tasks as their schedule changes.'
            }
        ]
    }),
})