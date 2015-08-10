/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     08-08-2015 21:04:36                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADJUNTOS') and o.name = 'FK_ADJUNTOS_REFERENCE_SOLICITU')
alter table ADJUNTOS
   drop constraint FK_ADJUNTOS_REFERENCE_SOLICITU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AUDITORIA') and o.name = 'FK_AUDITORI_REFERENCE_USUARIO')
alter table AUDITORIA
   drop constraint FK_AUDITORI_REFERENCE_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETALLESOLICITUD') and o.name = 'FK_DETALLES_REFERENCE_USUARIO')
alter table DETALLESOLICITUD
   drop constraint FK_DETALLES_REFERENCE_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETALLESOLICITUD') and o.name = 'FK_DETALLES_REFERENCE_SOLICITU')
alter table DETALLESOLICITUD
   drop constraint FK_DETALLES_REFERENCE_SOLICITU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETALLESOLICITUD') and o.name = 'FK_DETALLES_REFERENCE_ESTADOS')
alter table DETALLESOLICITUD
   drop constraint FK_DETALLES_REFERENCE_ESTADOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETALLESOLICITUD') and o.name = 'FK_DETALLES_REFERENCE_FLUJOSOL')
alter table DETALLESOLICITUD
   drop constraint FK_DETALLES_REFERENCE_FLUJOSOL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ERRORES') and o.name = 'FK_ERRORES_REFERENCE_USUARIO')
alter table ERRORES
   drop constraint FK_ERRORES_REFERENCE_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FLUJOSOLICITUD') and o.name = 'FK_FLUJOSOL_REFERENCE_ACTIVIDA')
alter table FLUJOSOLICITUD
   drop constraint FK_FLUJOSOL_REFERENCE_ACTIVIDA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FLUJOSOLICITUD') and o.name = 'FK_FLUJOSOL_REFERENCE_TIPOSOLI')
alter table FLUJOSOLICITUD
   drop constraint FK_FLUJOSOL_REFERENCE_TIPOSOLI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FLUJOSOLICITUD') and o.name = 'FK_FLUJOSOL_REFERENCE_UNIDADES')
alter table FLUJOSOLICITUD
   drop constraint FK_FLUJOSOL_REFERENCE_UNIDADES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ROLESPRIVILEGIOS') and o.name = 'FK_ROLESPRI_REFERENCE_PRIVILEG')
alter table ROLESPRIVILEGIOS
   drop constraint FK_ROLESPRI_REFERENCE_PRIVILEG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ROLESPRIVILEGIOS') and o.name = 'FK_ROLESPRI_REFERENCE_ROL')
alter table ROLESPRIVILEGIOS
   drop constraint FK_ROLESPRI_REFERENCE_ROL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SOLICITUD') and o.name = 'FK_SOLICITU_REFERENCE_TIPOSOLI')
alter table SOLICITUD
   drop constraint FK_SOLICITU_REFERENCE_TIPOSOLI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIO') and o.name = 'FK_USUARIO_REFERENCE_UNIDADES')
alter table USUARIO
   drop constraint FK_USUARIO_REFERENCE_UNIDADES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIO') and o.name = 'FK_USUARIO_REFERENCE_ROL')
alter table USUARIO
   drop constraint FK_USUARIO_REFERENCE_ROL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ACTIVIDAD')
            and   type = 'U')
   drop table ACTIVIDAD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADJUNTOS')
            and   type = 'U')
   drop table ADJUNTOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AUDITORIA')
            and   type = 'U')
   drop table AUDITORIA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DETALLESOLICITUD')
            and   type = 'U')
   drop table DETALLESOLICITUD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ERRORES')
            and   type = 'U')
   drop table ERRORES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ESTADOS')
            and   type = 'U')
   drop table ESTADOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FERIADOFINSEMANAS')
            and   type = 'U')
   drop table FERIADOFINSEMANAS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FLUJOSOLICITUD')
            and   type = 'U')
   drop table FLUJOSOLICITUD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRIVILEGIOS')
            and   type = 'U')
   drop table PRIVILEGIOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ROL')
            and   type = 'U')
   drop table ROL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ROLESPRIVILEGIOS')
            and   type = 'U')
   drop table ROLESPRIVILEGIOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SOLICITUD')
            and   type = 'U')
   drop table SOLICITUD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIPOSOLICITUD')
            and   type = 'U')
   drop table TIPOSOLICITUD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UNIDADES')
            and   type = 'U')
   drop table UNIDADES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO')
            and   type = 'U')
   drop table USUARIO
go

/*==============================================================*/
/* Table: ACTIVIDAD                                             */
/*==============================================================*/
create table ACTIVIDAD (
   CODACTIVIDAD         int                  identity,
   DESCRIPCION          varchar(50)          null,
   DURACION             int                  null,
   ESTADOACTIVIDAD      int                  null,
   constraint PK_ACTIVIDAD primary key (CODACTIVIDAD)
)
go

/*==============================================================*/
/* Table: ADJUNTOS                                              */
/*==============================================================*/
create table ADJUNTOS (
   IDARCHIVO            int                  identity,
   FOLIOSOLICITUD       int                  null,
   NOMBREARCHIVO        varchar(50)          null,
   ARCHIVOPDF           varbinary(Max)       null,
   TIPOADJUNTO          varchar(1)           null,
   SECUENCIA            int                  null,
   constraint PK_ADJUNTOS primary key (IDARCHIVO)
)
go

/*==============================================================*/
/* Table: AUDITORIA                                             */
/*==============================================================*/
create table AUDITORIA (
   RUTUSUARIO           varchar(10)          null,
   FECHA                datetime             null,
   IP                   varchar(Max)         null,
   MODULO               varchar(Max)         null,
   ACCION               varchar(Max)         null,
   OBSERVACION          varchar(Max)         null,
   DISPOSITIVO          varchar(50)          null,
   NOMBREMAQUINA        varchar(Max)         null,
   MACADDRESS           varchar(Max)         null
)
go

/*==============================================================*/
/* Table: DETALLESOLICITUD                                      */
/*==============================================================*/
create table DETALLESOLICITUD (
   FOLIOSOLICITUD       int                  not null,
   SECUENCIA            int                  not null,
   CODTIPOSOLICITUD     int                  not null,
   CODACTIVIDAD         int                  not null,
   CODUNIDAD            int                  not null,
   RUTUSUARIO           varchar(10)          null,
   GLOSADETALLESOL      varchar(500)         null,
   CODESTADO            int                  not null,
   FECHAEJECACTIVIDAD   datetime             null,
   FECHAVENCSOL         datetime             null,
   DIASATRASO           int                  null,
   FECHARESOLUCION      datetime             null,
   FECHARECEP           datetime             null,
   ESTAAPROBADO         int                  null,
   ETAPA                int                  null,
   constraint PK_DETALLESOLICITUD primary key (FOLIOSOLICITUD, SECUENCIA, CODTIPOSOLICITUD, CODACTIVIDAD, CODUNIDAD)
)
go

/*==============================================================*/
/* Table: ERRORES                                               */
/*==============================================================*/
create table ERRORES (
   IDERROR              int                  identity,
   RUTUSUARIO           varchar(10)          null,
   NOMBREPROCEDIMIENTO  varchar(100)         null,
   CODERROR             varchar(100)         null,
   GLOSAERROR           varchar(Max)         null,
   OBSERVACION          varchar(Max)         null,
   FECHA                datetime             null,
   METODO               varchar(100)         null,
   constraint PK_ERRORES primary key (IDERROR)
)
go

/*==============================================================*/
/* Table: ESTADOS                                               */
/*==============================================================*/
create table ESTADOS (
   CODESTADO            int                  not null,
   DESCESTADO           varchar(50)          not null,
   constraint PK_ESTADOS primary key (CODESTADO)
)
go

/*==============================================================*/
/* Table: FERIADOFINSEMANAS                                     */
/*==============================================================*/
create table FERIADOFINSEMANAS (
   CODFERIADO           int                  identity,
   DESCRIPCIONFERIADO   varchar(50)          null,
   FECHAFERIADO         datetime             null,
   constraint PK_FERIADOFINSEMANAS primary key (CODFERIADO)
)
go

/*==============================================================*/
/* Table: FLUJOSOLICITUD                                        */
/*==============================================================*/
create table FLUJOSOLICITUD (
   SECUENCIA            int                  not null,
   CODTIPOSOLICITUD     int                  not null,
   CODACTIVIDAD         int                  not null,
   CODUNIDAD            int                  not null,
   APROBADOR            int                  null,
   ESTADO               int                  null,
   SI                   varchar(2)           null,
   NO                   varchar(2)           null,
   BIFURCACION          int                  null,
   constraint PK_FLUJOSOLICITUD primary key (SECUENCIA, CODTIPOSOLICITUD, CODACTIVIDAD, CODUNIDAD)
)
go

/*==============================================================*/
/* Table: PRIVILEGIOS                                           */
/*==============================================================*/
create table PRIVILEGIOS (
   CODPRIVILEGIOS       int                  identity,
   DESCPRIVILEGIOS      varchar(50)          null,
   NOMPRIVILEGIOS       varchar(50)          null,
   ESTADOPRIVILEGIOS    int                  null,
   constraint PK_PRIVILEGIOS primary key (CODPRIVILEGIOS)
)
go

/*==============================================================*/
/* Table: ROL                                                   */
/*==============================================================*/
create table ROL (
   CODROL               int                  identity,
   DESCRIPCION          varchar(50)          null,
   ESTADOROL            int                  null,
   constraint PK_ROL primary key (CODROL)
)
go

/*==============================================================*/
/* Table: ROLESPRIVILEGIOS                                      */
/*==============================================================*/
create table ROLESPRIVILEGIOS (
   CODPRIVILEGIOS       int                  null,
   CODROL               int                  null,
   ESTADOROLPRIVI       int                  null
)
go

/*==============================================================*/
/* Table: SOLICITUD                                             */
/*==============================================================*/
create table SOLICITUD (
   FOLIOSOLICITUD       int                  identity,
   CODCLI               varchar(30)          null,
   CODCARR              varchar(30)          null,
   CODTIPOSOLICITUD     int                  null,
   FECHASOLICITUD       datetime             null,
   GLOSASOLICITUD       varchar(500)         null,
   OBSSOLUCION          varchar(500)         null,
   FECHARESOLUCION      datetime             null,
   CODESTADOSOL         int                  null,
   OPCION               varchar(2)           null,
   CELULARDECONTACTO    varchar(10)          null,
   EMAILCONTACTO        varchar(50)          null,
   FECHAESTIMADARESOL   datetime             null,
   ORIGEN               varchar(1)           null,
   constraint PK_SOLICITUD primary key (FOLIOSOLICITUD)
)
go

/*==============================================================*/
/* Table: TIPOSOLICITUD                                         */
/*==============================================================*/
create table TIPOSOLICITUD (
   CODTIPOSOLICITUD     int                  identity,
   DESCTIPOSOLICITUD    varchar(50)          null,
   ESTADOSOLICITUD      int                  null,
   FECHAINICIO          datetime             null,
   FECHAFIN             datetime             null,
   CANTMAXSOLICITUD     int                  null,
   ORIGEN               varchar(1)           null,
   CANTMAXDOC           int                  null,
   constraint PK_TIPOSOLICITUD primary key (CODTIPOSOLICITUD)
)
go

/*==============================================================*/
/* Table: UNIDADES                                              */
/*==============================================================*/
create table UNIDADES (
   CODUNIDAD            int                  identity,
   DESCUNIDAD           varchar(50)          null,
   ESTADOUNIDAD         int                  null,
   constraint PK_UNIDADES primary key (CODUNIDAD)
)
go

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO (
   RUTUSUARIO           varchar(10)          not null,
   CODROL               int                  null,
   CODUNIDAD            int                  null,
   ESTADOUSUARIO        int                  null,
   PASSWORD             varchar(300)         null,
   NOMBRE               varchar(50)          null,
   APELLIDO             varchar(50)          null,
   TELEFONO             varchar(10)          null,
   EMAILUSUARIO         varchar(50)          null,
   DEPENDE              varchar(10)          null,
   FOTO                 varbinary(Max)       null,
   FOTOXL               varbinary(Max)       null,
   constraint PK_USUARIO primary key (RUTUSUARIO)
)
go

alter table ADJUNTOS
   add constraint FK_ADJUNTOS_REFERENCE_SOLICITU foreign key (FOLIOSOLICITUD)
      references SOLICITUD (FOLIOSOLICITUD)
go

alter table AUDITORIA
   add constraint FK_AUDITORI_REFERENCE_USUARIO foreign key (RUTUSUARIO)
      references USUARIO (RUTUSUARIO)
go

alter table DETALLESOLICITUD
   add constraint FK_DETALLES_REFERENCE_USUARIO foreign key (RUTUSUARIO)
      references USUARIO (RUTUSUARIO)
go

alter table DETALLESOLICITUD
   add constraint FK_DETALLES_REFERENCE_SOLICITU foreign key (FOLIOSOLICITUD)
      references SOLICITUD (FOLIOSOLICITUD)
go

alter table DETALLESOLICITUD
   add constraint FK_DETALLES_REFERENCE_ESTADOS foreign key (CODESTADO)
      references ESTADOS (CODESTADO)
go

alter table DETALLESOLICITUD
   add constraint FK_DETALLES_REFERENCE_FLUJOSOL foreign key (SECUENCIA, CODTIPOSOLICITUD, CODACTIVIDAD, CODUNIDAD)
      references FLUJOSOLICITUD (SECUENCIA, CODTIPOSOLICITUD, CODACTIVIDAD, CODUNIDAD)
go

alter table ERRORES
   add constraint FK_ERRORES_REFERENCE_USUARIO foreign key (RUTUSUARIO)
      references USUARIO (RUTUSUARIO)
go

alter table FLUJOSOLICITUD
   add constraint FK_FLUJOSOL_REFERENCE_ACTIVIDA foreign key (CODACTIVIDAD)
      references ACTIVIDAD (CODACTIVIDAD)
go

alter table FLUJOSOLICITUD
   add constraint FK_FLUJOSOL_REFERENCE_TIPOSOLI foreign key (CODTIPOSOLICITUD)
      references TIPOSOLICITUD (CODTIPOSOLICITUD)
go

alter table FLUJOSOLICITUD
   add constraint FK_FLUJOSOL_REFERENCE_UNIDADES foreign key (CODUNIDAD)
      references UNIDADES (CODUNIDAD)
go

alter table ROLESPRIVILEGIOS
   add constraint FK_ROLESPRI_REFERENCE_PRIVILEG foreign key (CODPRIVILEGIOS)
      references PRIVILEGIOS (CODPRIVILEGIOS)
go

alter table ROLESPRIVILEGIOS
   add constraint FK_ROLESPRI_REFERENCE_ROL foreign key (CODROL)
      references ROL (CODROL)
go

alter table SOLICITUD
   add constraint FK_SOLICITU_REFERENCE_TIPOSOLI foreign key (CODTIPOSOLICITUD)
      references TIPOSOLICITUD (CODTIPOSOLICITUD)
go

alter table USUARIO
   add constraint FK_USUARIO_REFERENCE_UNIDADES foreign key (CODUNIDAD)
      references UNIDADES (CODUNIDAD)
go

alter table USUARIO
   add constraint FK_USUARIO_REFERENCE_ROL foreign key (CODROL)
      references ROL (CODROL)
go

