using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template.Outbox.Contexts.Outbox.Migrations;

/// <inheritdoc />
public partial class MassTransitOutbox : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey(
            name: "PK_OutboxMessage",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "CreatedOn",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "ModifiedOn",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "Payload",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "Status",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.RenameColumn(
            name: "Type",
            schema: "outbox",
            table: "OutboxMessage",
            newName: "Body");

        migrationBuilder.RenameColumn(
            name: "Id",
            schema: "outbox",
            table: "OutboxMessage",
            newName: "MessageId");

        migrationBuilder.AddColumn<long>(
            name: "SequenceNumber",
            schema: "outbox",
            table: "OutboxMessage",
            type: "bigint",
            nullable: false,
            defaultValue: 0L)
            .Annotation("SqlServer:Identity", "1, 1");

        migrationBuilder.AddColumn<string>(
            name: "ContentType",
            schema: "outbox",
            table: "OutboxMessage",
            type: "nvarchar(256)",
            maxLength: 256,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<Guid>(
            name: "ConversationId",
            schema: "outbox",
            table: "OutboxMessage",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "CorrelationId",
            schema: "outbox",
            table: "OutboxMessage",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "DestinationAddress",
            schema: "outbox",
            table: "OutboxMessage",
            type: "nvarchar(256)",
            maxLength: 256,
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "EnqueueTime",
            schema: "outbox",
            table: "OutboxMessage",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "ExpirationTime",
            schema: "outbox",
            table: "OutboxMessage",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "FaultAddress",
            schema: "outbox",
            table: "OutboxMessage",
            type: "nvarchar(256)",
            maxLength: 256,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Headers",
            schema: "outbox",
            table: "OutboxMessage",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "InboxConsumerId",
            schema: "outbox",
            table: "OutboxMessage",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "InboxMessageId",
            schema: "outbox",
            table: "OutboxMessage",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "InitiatorId",
            schema: "outbox",
            table: "OutboxMessage",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "OutboxId",
            schema: "outbox",
            table: "OutboxMessage",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Properties",
            schema: "outbox",
            table: "OutboxMessage",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "RequestId",
            schema: "outbox",
            table: "OutboxMessage",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "ResponseAddress",
            schema: "outbox",
            table: "OutboxMessage",
            type: "nvarchar(256)",
            maxLength: 256,
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "SentTime",
            schema: "outbox",
            table: "OutboxMessage",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<string>(
            name: "SourceAddress",
            schema: "outbox",
            table: "OutboxMessage",
            type: "nvarchar(256)",
            maxLength: 256,
            nullable: true);

        migrationBuilder.AddPrimaryKey(
            name: "PK_OutboxMessage",
            schema: "outbox",
            table: "OutboxMessage",
            column: "SequenceNumber");

        migrationBuilder.CreateTable(
            name: "InboxState",
            schema: "outbox",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ConsumerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                LockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                Received = table.Column<DateTime>(type: "datetime2", nullable: false),
                ReceiveCount = table.Column<int>(type: "int", nullable: false),
                ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                Consumed = table.Column<DateTime>(type: "datetime2", nullable: true),
                Delivered = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastSequenceNumber = table.Column<long>(type: "bigint", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_InboxState", x => x.Id);
                table.UniqueConstraint("AK_InboxState_MessageId_ConsumerId", x => new { x.MessageId, x.ConsumerId });
            });

        migrationBuilder.CreateTable(
            name: "OutboxState",
            schema: "outbox",
            columns: table => new
            {
                OutboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                LockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                Delivered = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastSequenceNumber = table.Column<long>(type: "bigint", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OutboxState", x => x.OutboxId);
            });

        migrationBuilder.CreateIndex(
            name: "IX_OutboxMessage_EnqueueTime",
            schema: "outbox",
            table: "OutboxMessage",
            column: "EnqueueTime");

        migrationBuilder.CreateIndex(
            name: "IX_OutboxMessage_ExpirationTime",
            schema: "outbox",
            table: "OutboxMessage",
            column: "ExpirationTime");

        migrationBuilder.CreateIndex(
            name: "IX_OutboxMessage_InboxMessageId_InboxConsumerId_SequenceNumber",
            schema: "outbox",
            table: "OutboxMessage",
            columns: new[] { "InboxMessageId", "InboxConsumerId", "SequenceNumber" },
            unique: true,
            filter: "[InboxMessageId] IS NOT NULL AND [InboxConsumerId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_OutboxMessage_OutboxId_SequenceNumber",
            schema: "outbox",
            table: "OutboxMessage",
            columns: new[] { "OutboxId", "SequenceNumber" },
            unique: true,
            filter: "[OutboxId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_InboxState_Delivered",
            schema: "outbox",
            table: "InboxState",
            column: "Delivered");

        migrationBuilder.CreateIndex(
            name: "IX_OutboxState_Created",
            schema: "outbox",
            table: "OutboxState",
            column: "Created");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "InboxState",
            schema: "outbox");

        migrationBuilder.DropTable(
            name: "OutboxState",
            schema: "outbox");

        migrationBuilder.DropPrimaryKey(
            name: "PK_OutboxMessage",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropIndex(
            name: "IX_OutboxMessage_EnqueueTime",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropIndex(
            name: "IX_OutboxMessage_ExpirationTime",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropIndex(
            name: "IX_OutboxMessage_InboxMessageId_InboxConsumerId_SequenceNumber",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropIndex(
            name: "IX_OutboxMessage_OutboxId_SequenceNumber",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "SequenceNumber",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "ContentType",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "ConversationId",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "CorrelationId",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "DestinationAddress",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "EnqueueTime",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "ExpirationTime",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "FaultAddress",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "Headers",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "InboxConsumerId",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "InboxMessageId",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "InitiatorId",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "OutboxId",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "Properties",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "RequestId",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "ResponseAddress",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "SentTime",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.DropColumn(
            name: "SourceAddress",
            schema: "outbox",
            table: "OutboxMessage");

        migrationBuilder.RenameColumn(
            name: "MessageId",
            schema: "outbox",
            table: "OutboxMessage",
            newName: "Id");

        migrationBuilder.RenameColumn(
            name: "Body",
            schema: "outbox",
            table: "OutboxMessage",
            newName: "Type");

        migrationBuilder.AddColumn<DateTimeOffset>(
            name: "CreatedOn",
            schema: "outbox",
            table: "OutboxMessage",
            type: "datetimeoffset",
            nullable: false,
            defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

        migrationBuilder.AddColumn<DateTimeOffset>(
            name: "ModifiedOn",
            schema: "outbox",
            table: "OutboxMessage",
            type: "datetimeoffset",
            nullable: false,
            defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

        migrationBuilder.AddColumn<string>(
            name: "Payload",
            schema: "outbox",
            table: "OutboxMessage",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "Status",
            schema: "outbox",
            table: "OutboxMessage",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddPrimaryKey(
            name: "PK_OutboxMessage",
            schema: "outbox",
            table: "OutboxMessage",
            column: "Id");
    }
}
