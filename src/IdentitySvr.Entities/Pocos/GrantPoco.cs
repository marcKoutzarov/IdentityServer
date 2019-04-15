using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySvr.Entities.Pocos
{
    public class GrantPoco
    {
        public int Id { get; set; }
        //
        // Summary:
        //     Gets or sets the key.
        public string Key { get; set; }
        //
        // Summary:
        //     Gets the type.
        public string Type { get; set; }
        //
        // Summary:
        //     Gets the subject identifier.
        public string SubjectId { get; set; }
        //
        // Summary:
        //     Gets the client identifier.
        public string ClientId { get; set; }
        //
        // Summary:
        //     Gets or sets the creation time.
        public DateTime CreationTime { get; set; }
        //
        // Summary:
        //     Gets or sets the expiration.
        public DateTime? Expiration { get; set; }
        //
        // Summary:
        //     Gets or sets the data.
        public string Data { get; set; }
    }
}
