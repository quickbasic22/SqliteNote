using SQLite;
using SqliteNote.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqliteNote.Services
{
    public class NoteDatabase : Services.INoteDatabase<Models.Item>
    {
        readonly SQLiteAsyncConnection database;
        public NoteDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Models.Item>().Wait();
        }
        public Task<List<Item>> GetNotesAsync(bool forceRefresh = false)
        {
            // Get all notes.
            return database.Table<Models.Item>().ToListAsync();
        }
        public Task<Models.Item> GetNoteAsync(int id)
        {
            return database.Table<Models.Item>()
                              .Where(x => x.Id == id)
                              .FirstOrDefaultAsync();
        }
        public Task<int> SaveNoteAsync(Models.Item note)
        {
            // Get a specific note.
            if (note.Id != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(note);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Models.Item note)
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }



    }
}
