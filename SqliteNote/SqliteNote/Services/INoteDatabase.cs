using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqliteNote.Services
{
    public interface INoteDatabase<T>
    {
        Task<int> DeleteNoteAsync(T note);
        Task<T> GetNoteAsync(int id);
        Task<List<T>> GetNotesAsync(bool forceRefresh = false);
        Task<int> SaveNoteAsync(T note);
    }
}