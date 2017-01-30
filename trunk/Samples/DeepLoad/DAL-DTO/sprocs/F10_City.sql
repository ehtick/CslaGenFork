/****** Object:  StoredProcedure [AddF10_City] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF10_City]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF10_City]
GO

CREATE PROCEDURE [AddF10_City]
    @City_ID int OUTPUT,
    @Parent_Region_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities */
        INSERT INTO [5_Cities]
        (
            [Parent_Region_ID],
            [City_Name]
        )
        VALUES
        (
            @Parent_Region_ID,
            @City_Name
        )

        /* Return new primary key */
        SET @City_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateF10_City] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF10_City]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF10_City]
GO

CREATE PROCEDURE [UpdateF10_City]
    @City_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities */
        UPDATE [5_Cities]
        SET
            [City_Name] = @City_Name
        WHERE
            [City_ID] = @City_ID

    END
GO

/****** Object:  StoredProcedure [DeleteF10_City] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF10_City]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF10_City]
GO

CREATE PROCEDURE [DeleteF10_City]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child F12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Mark child F11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Mark child F11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Mark F10_City object as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities].[City_ID] = @City_ID

    END
GO
