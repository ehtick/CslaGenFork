/****** Object:  StoredProcedure [AddF02Level1] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF02Level1]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF02Level1]
GO

CREATE PROCEDURE [AddF02Level1]
    @Level_1_ID int OUTPUT,
    @Level_1_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1 */
        INSERT INTO [Level_1]
        (
            [Level_1_Name]
        )
        VALUES
        (
            @Level_1_Name
        )

        /* Return new primary key */
        SET @Level_1_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateF02Level1] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF02Level1]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF02Level1]
GO

CREATE PROCEDURE [UpdateF02Level1]
    @Level_1_ID int,
    @Level_1_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Level_1_ID] FROM [Level_1]
            WHERE
                [Level_1_ID] = @Level_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F02Level1'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1 */
        UPDATE [Level_1]
        SET
            [Level_1_Name] = @Level_1_Name
        WHERE
            [Level_1_ID] = @Level_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteF02Level1] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF02Level1]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF02Level1]
GO

CREATE PROCEDURE [DeleteF02Level1]
    @Level_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Level_1_ID] FROM [Level_1]
            WHERE
                [Level_1_ID] = @Level_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F02Level1'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child F12Level111111 as not active */
        UPDATE [Level_1_1_1_1_1_1]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1].[QarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child F11Level111111ReChild as not active */
        UPDATE [Level_1_1_1_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_ReChild].[CQarentID2] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child F11Level111111Child as not active */
        UPDATE [Level_1_1_1_1_1_1_Child]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_Child].[CQarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child F10Level11111 as not active */
        UPDATE [Level_1_1_1_1_1]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child F09Level11111ReChild as not active */
        UPDATE [Level_1_1_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_ReChild].[CNarentID2] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child F09Level11111Child as not active */
        UPDATE [Level_1_1_1_1_1_Child]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_Child].[CNarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child F08Level1111 as not active */
        UPDATE [Level_1_1_1_1]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child F07Level1111ReChild as not active */
        UPDATE [Level_1_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1_ReChild].[CLarentID2] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child F07Level1111Child as not active */
        UPDATE [Level_1_1_1_1_Child]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1_Child].[CLarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child F06Level111 as not active */
        UPDATE [Level_1_1_1]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child F05Level111Child as not active */
        UPDATE [Level_1_1_1_Child]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_Child]
            INNER JOIN [Level_1_1] ON [Level_1_1_1_Child].[CMarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child F05Level111ReChild as not active */
        UPDATE [Level_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_ReChild]
            INNER JOIN [Level_1_1] ON [Level_1_1_1_ReChild].[CMarentID2] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child F04Level11 as not active */
        UPDATE [Level_1_1]
        SET    [IsActive] = 'false'
        FROM [Level_1_1]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child F03Level11ReChild as not active */
        UPDATE [Level_1_1_ReChild]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_ReChild]
            INNER JOIN [Level_1] ON [Level_1_1_ReChild].[CParentID2] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark child F03Level11Child as not active */
        UPDATE [Level_1_1_Child]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_Child]
            INNER JOIN [Level_1] ON [Level_1_1_Child].[CParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Mark F02Level1 object as not active */
        UPDATE [Level_1]
        SET    [IsActive] = 'false'
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

    END
GO
