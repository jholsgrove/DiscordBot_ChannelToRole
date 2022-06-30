using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Modules
{
    [Name("Example")]
    public class ExampleModule : ModuleBase<SocketCommandContext>
    {
        [Command("createroles"), Priority(0)]
        [Summary("Get text channels and create roles based on their names. Does not create duplicates.")]
        //[RequireUserPermission(GuildPermission.ManageRoles)]
        public async Task CreateRoles()
        {
            var getCurrentRoles = Context.Guild.Roles;
            var listOfRoles = new List<SocketRole>();
            var listString = new List<string>();

            // Get all roles and add the enum value to a list of socket roles
            foreach (var role in getCurrentRoles)
            {
                listOfRoles.Add(role);
            }

            // get each socket role name and put it in a list of strings
            foreach (var role in listOfRoles)
            {
                listString.Add(role.Name);
            }
            
            // Get all channels
            var textChannels = Context.Guild.TextChannels;

            foreach (var channel in textChannels)
            {
                // if the channel name exists in the existing roles list
                if (listString.Contains(channel.Name))
                {
                    // do nothing
                }
                else
                {
                    // otherwise create it
                    await Context.Guild.CreateRoleAsync(channel.Name, null, Color.Teal, false);
                }
            }
        }
    }
}
