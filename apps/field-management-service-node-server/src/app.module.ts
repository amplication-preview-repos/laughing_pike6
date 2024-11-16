import { Module } from "@nestjs/common";
import { LocationModule } from "./location/location.module";
import { RoleModule } from "./role/role.module";
import { CompanySiteModule } from "./companySite/companySite.module";
import { TransactionModule } from "./transaction/transaction.module";
import { TeamModule } from "./team/team.module";
import { RatingModule } from "./rating/rating.module";
import { BookingModule } from "./booking/booking.module";
import { FieldModelModule } from "./fieldModel/fieldModel.module";
import { PasswordRecoveryLogModule } from "./passwordRecoveryLog/passwordRecoveryLog.module";
import { UserModule } from "./user/user.module";
import { HealthModule } from "./health/health.module";
import { PrismaModule } from "./prisma/prisma.module";
import { SecretsManagerModule } from "./providers/secrets/secretsManager.module";
import { ServeStaticModule } from "@nestjs/serve-static";
import { ServeStaticOptionsService } from "./serveStaticOptions.service";
import { ConfigModule, ConfigService } from "@nestjs/config";
import { GraphQLModule } from "@nestjs/graphql";
import { ApolloDriver, ApolloDriverConfig } from "@nestjs/apollo";

@Module({
  controllers: [],
  imports: [
    LocationModule,
    RoleModule,
    CompanySiteModule,
    TransactionModule,
    TeamModule,
    RatingModule,
    BookingModule,
    FieldModelModule,
    PasswordRecoveryLogModule,
    UserModule,
    HealthModule,
    PrismaModule,
    SecretsManagerModule,
    ConfigModule.forRoot({ isGlobal: true }),
    ServeStaticModule.forRootAsync({
      useClass: ServeStaticOptionsService,
    }),
    GraphQLModule.forRootAsync<ApolloDriverConfig>({
      driver: ApolloDriver,
      useFactory: (configService: ConfigService) => {
        const playground = configService.get("GRAPHQL_PLAYGROUND");
        const introspection = configService.get("GRAPHQL_INTROSPECTION");
        return {
          autoSchemaFile: "schema.graphql",
          sortSchema: true,
          playground,
          introspection: playground || introspection,
        };
      },
      inject: [ConfigService],
      imports: [ConfigModule],
    }),
  ],
  providers: [],
})
export class AppModule {}
