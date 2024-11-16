import { Module } from "@nestjs/common";
import { CompanySiteModuleBase } from "./base/companySite.module.base";
import { CompanySiteService } from "./companySite.service";
import { CompanySiteController } from "./companySite.controller";
import { CompanySiteResolver } from "./companySite.resolver";

@Module({
  imports: [CompanySiteModuleBase],
  controllers: [CompanySiteController],
  providers: [CompanySiteService, CompanySiteResolver],
  exports: [CompanySiteService],
})
export class CompanySiteModule {}
