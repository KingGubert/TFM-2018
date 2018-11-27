--*******************************************
--Execute this twice JS 25.05.2018
--*******************************************

if not exists (select * from master.dbo.sysdatabases where name = 'TERRAFORMING')
create database TERRAFORMING

go	
use TERRAFORMING
----------------------------------------------------------------------------------------------------------Oberfläche Mars
go

if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'sys_tblSurfaceSpotsMars'))         
  execute ('drop table sys_tblSurfaceSpotsMars')

create table sys_tblSurfaceSpotsMars ( 
                       nSpotID                int primary key
                     , nSpotType              nvarchar (255)
                     , szSpotName             nvarchar (255)
                     , nOwner                 nvarchar (255)
                     , bIsLocked              bit
                     , nTileType              int
                     , szTileName             nvarchar (255)
                     , nPB_Steel              int
                     , nPB_Titan              int
                     , nPB_Plant              int
                     , nPB_Cards              int
                     , nPB_Money              int
                     , nPB_Heat               int
                     , nPB_Ocean              int
                     , nPB_1                  int
                     , nPB_2                  int
                     , nPB_3                  int
                     )     


go
----------------------------------------------------------------------------------------------------------Oberfläche Hellas


if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'sys_tblSurfaceSpotsHellas'))         
  execute ('drop table sys_tblSurfaceSpotsHellas')

create table sys_tblSurfaceSpotsHellas ( 
                       nSpotID                int primary key
                     , nSpotType              nvarchar (255)
                     , szSpotName             nvarchar (255)
                     , nOwner                 nvarchar (255)
                     , bIsLocked              bit
                     , nTileType              int
                     , szTileName             nvarchar (255)
                     , nPB_Steel              int
                     , nPB_Titan              int
                     , nPB_Plant              int
                     , nPB_Cards              int
                     , nPB_Money              int
                     , nPB_Heat               int
                     , nPB_Ocean              int
                     , nPB_1                  int
                     , nPB_2                  int
                     , nPB_3                  int
                     )     

go
----------------------------------------------------------------------------------------------------------Oberfläche Elysium


if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'sys_tblSurfaceSpotsElysium'))         
  execute ('drop table sys_tblSurfaceSpotsElysium')

create table sys_tblSurfaceSpotsElysium ( 
                       nSpotID                int primary key
                     , nSpotType              nvarchar (255)
                     , szSpotName             nvarchar (255)
                     , nOwner                 nvarchar (255)
                     , bIsLocked              bit
                     , nTileType              int
                     , szTileName             nvarchar (255)
                     , nPB_Steel              int
                     , nPB_Titan              int
                     , nPB_Plant              int
                     , nPB_Cards              int
                     , nPB_Money              int
                     , nPB_Heat               int
                     , nPB_Ocean              int
                     , nPB_1                  int
                     , nPB_2                  int
                     , nPB_3                  int
                     )     

go
----------------------------------------------------------------------------------------------------------Player InfoTable

if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'sys_tblPlayerInfo'))         
  execute ('drop table sys_tblPlayerInfo')

create table sys_tblPlayerInfo ( 
                          nPlayerID          int primary key 
                        , szPlayerName       nvarchar (255)
                        , szPlayerColour     int 
                        , nCNT_TFR           int
                        , nCNT_CardsPlayed   int
                        , nCardsPlayed       int
                        , nTileCNTCity       int
                        , nTileCNTOcean      int
                        , nTileCNTGreenery   int
                        , bStatus_Active     bit
                        , bStatus_HasPassed  bit
                        , nDisc_All          int -- Discount auf alles
                        , nDisc_Earth        int -- Discount auf EarthKarten
                        , nDisc_Space        int -- Discount auf Spacekarten
                        )
go
                                
----------------------------------------------------------------------------------------------------------Player CardTags

if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'sys_tblPlayerTags'))         
  execute ('drop table sys_tblPlayerTags')

create table sys_tblPlayerTags ( 
                             nPlayerID          int primary key 
                           , nTAGCNT_Building   int
                           , nTAGCNT_Space      int
                           , nTAGCNT_City       int
                           , nTAGCNT_Animal     int
                           , nTAGCNT_Microbe    int
                           , nTAGCNT_Plant      int
                           , nTAGCNT_Earth      int
                           , nTAGCNT_Jovian     int
                           , nTAGCNT_Event      int
                           , nTAGCNT_Venus      int
                           , nTAGCNT_Science    int
                           )
go
                                
                                                              
  ----------------------------------------------------------------------------------------------------------Player Production and Ressources
if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'sys_tblPlayerRESandProd'))         
  execute ('drop table sys_tblPlayerRESandProd')

create table sys_tblPlayerRESandProd ( 
                                       nPlayerID          int primary key 
                                     , nProd_Money        int
                                     , nProd_Steel        int
                                     , nProd_Titan        int
                                     , nProd_Plants       int
                                     , nProd_Energy       int
                                     , nProd_Heat         int
                                     , nRes_Money         int
                                     , nRes_Steel         int
                                     , nRes_Titan         int
                                     , nRes_Plants        int
                                     , nRes_Energy        int
                                     , nRes_Heat          int                
                                     )
go                              
                                

----------------------------------------------------------------------------------------------------------Card Info

if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'sys_tblCardInfo'))         
  execute ('drop table sys_tblCardInfo')


create table sys_tblCardInfo ( 
                               nCardID                   int primary key
                             , nCardCost                 int
                             , nCardType                 nvarchar(255)     -- CardType = Project, Event, Action
                             , nCardOwner                int               --CardOwner = PlayerID
                             , szCardName                nvarchar(255)
                             , szCardRequirementTXT      nvarchar(max)
                             , szCardEffectTXT           nvarchar(max)
                             , szCardFlavourTXT          nvarchar(max)
                             , nConstraint               int               -- null = none, 0 = min, 1 = max
                             , nHoldsRessource           int               -- 0 = no, 1 = yes
                             , nRequiresTarget           int               -- 0 = no, 1 = yes
                             , szRessourceName           nvarchar(255)     -- Microbe, Animal, Science, Floater, Other 
                             , nRessourceType            int               -- 1 = Microbe, 2 = Animal, 3= Science, 4 = Floater, 5 = Other
                             , nTargetPlayerGain         int               -- SpielerID des Kartenziels (1-4), Pos effekt
                             , nTargetPlayerLoss         int               -- SpielerID des Kartenziels (1-4), Neg effekt
                             , nCardStatus               int               -- 0 = available, 1 = Drawn, 2 = Played, 3 = Discarded, 4 = used
                             , imgCardPicture            varbinary(max)
                             )
                             
go     

  
----------------------------------------------------------------------------------------------------------Card Tags

if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'sys_tblCardTags'))         
  execute ('drop table sys_tblCardTags')


create table sys_tblCardTags ( 
                               nCardID                int primary key
                             , nTAGCNT_Building       int
                             , nTAGCNT_Space          int
                             , nTAGCNT_City           int
                             , nTAGCNT_Animal         int
                             , nTAGCNT_Microbe        int
                             , nTAGCNT_Plant          int
                             , nTAGCNT_Earth          int
                             , nTAGCNT_Jovian         int
                             , nTAGCNT_Event          int
                             , nTAGCNT_Venus          int
                             , nTAGCNT_Science        int
                             , nTagCNT_Energy         int
                             )
                             
go                                
     

----------------------------------------------------------------------------------------------------------Card Effects

if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'sys_tblCardEff'))         
  execute ('drop table sys_tblCardEff')


create table sys_tblCardEff ( 
                       nCardID                int primary key
                     , nGainRes_Money         int
                     , nGainProd_Money        int
                     , nGainRes_Steel         int
                     , nGainProd_Steel        int
                     , nGainRes_Titan         int
                     , nGainProd_Titan        int
                     , nGainRes_Microbe       int
                     , nGainRes_Animal        int
                     , nGainRes_Plant         int
                     , nGainProd_Plant        int
                     , nGainRes_Heat          int
                     , nGainProd_Heat         int
                     , nGainRes_Energy        int
                     , nGainProd_Energy       int
                     , nGain_TFR              int
                     , nGain_OceanTile        int
                     , nGain_Temperature      int
                     , nGain_Oxygen           int
                     , nGain_Greenerytile     int
                     )
                             
go                                
                                
 ----------------------------------------------------------------------------------------------------------Card Requirements

if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'sys_tblCardReq'))         
  execute ('drop table sys_tblCardReq')


create table sys_tblCardReq ( 
                              nCardID                int primary key
                            , nReq_Oxygen            int
                            , nReq_Temperature       int
                            , nReq_Oceans            int
                            , nReq_TFR               int
                            , nReq_ScienceTags       int
                            , nReq_GreeneryTiles     int
                            , nReq_SteelProd         int
                            , nReq_TitanProd         int
                            , nReq_EnergyProd        int
                            , nReq_Cities            int
                            )
                             
go                                    
                                
                                
 ----------------------------------------------------------------------------------------------------------GameInfo

if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'sys_tblGameInfo'))         
  execute ('drop table sys_tblGameInfo')


create table sys_tblGameInfo ( 
                              nGameID                int primary key
                            , nGameStatus            int             -- 0 = Active, 1 = Ended, 2 = Cancled
                            , szGameName             nvarchar(255)
                            , nPlayerCount           int
                            , dtStartTime            datetime
                            , dtEndTime              datetime
                            , nRoundCounter          int
                            , nActivePlayer          int
                            , nCNTParam_Oxygen       int -- Mars Oxygen Counter
                            , nCNTParam_Temperature  int -- Mars Temperature Counter
                            , nCNTParam_OceansInPlay int -- Mars Ocean Counter
                            , nCNTParam_Venus        int -- Venus Overall Counter    
                            , szPlayers              nvarchar(255) -- String with all PlayerNames 
                            )
                             
go                                    
                   
   



     