using Satori.Protocol.Events;

namespace Satori.Client;

public partial class SatoriBot
{
    public event EventHandler<Event>? EventReceived;

    #region Guild

    public event EventHandler<Event>? GuildAdded;

    public event EventHandler<Event>? GuildUpdated;

    public event EventHandler<Event>? GuildRemoved;

    public event EventHandler<Event>? GuildRequest;

    #endregion

    #region GuildMember

    public event EventHandler<Event>? GuildMemberAdded;

    public event EventHandler<Event>? GuildMemberUpdated;

    public event EventHandler<Event>? GuildMemberRemoved;

    public event EventHandler<Event>? GuildMemberRequest;

    #endregion

    #region GuildRole

    public event EventHandler<Event>? GuildRoleCreated;

    public event EventHandler<Event>? GuildRoleUpdated;

    public event EventHandler<Event>? GuildRoleDeleted;

    #endregion

    #region Login

    public event EventHandler<Event>? LoginAdded;

    public event EventHandler<Event>? LoginRemoved;

    public event EventHandler<Event>? LoginUpdated;

    #endregion

    #region Message

    public event EventHandler<Event>? MessageCreated;

    public event EventHandler<Event>? MessageUpdated;

    public event EventHandler<Event>? MessageDeleted;

    #endregion

    #region Reaction

    public event EventHandler<Event>? ReactionAdded;

    public event EventHandler<Event>? ReactionRemoved;

    #endregion

    #region User

    public event EventHandler<Event>? FriendRequest;

    #endregion
}