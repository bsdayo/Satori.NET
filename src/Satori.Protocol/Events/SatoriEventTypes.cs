namespace Satori.Protocol.Events;

public static class SatoriEventTypes
{
    #region Guild

    public const string GuildAdded = "guild-added";

    public const string GuildUpdated = "guild-updated";

    public const string GuildRemoved = "guild-removed";

    public const string GuildRequest = "guild-request";

    #endregion

    #region GuildMember

    public const string GuildMemberAdded = "guild-member-added";

    public const string GuildMemberUpdated = "guild-member-updated";

    public const string GuildMemberRemoved = "guild-member-removed";

    public const string GuildMemberRequest = "guild-member-request";

    #endregion

    #region GuildRole

    public const string GuildRoleCreated = "guild-role-created";

    public const string GuildRoleUpdated = "guild-role-updated";

    public const string GuildRoleDeleted = "guild-role-deleted";

    #endregion

    #region Login

    public const string LoginAdded = "login-added";

    public const string LoginRemoved = "login-removed";

    public const string LoginUpdated = "login-updated";

    #endregion

    #region Message

    public const string MessageCreated = "message-created";

    public const string MessageUpdated = "message-updated";

    public const string MessageDeleted = "message-deleted";

    #endregion

    #region Reaction

    public const string ReactionAdded = "reaction-added";

    public const string ReactionRemoved = "reaction-removed";

    #endregion

    #region User

    public const string FriendRequest = "friend-request";

    #endregion
}