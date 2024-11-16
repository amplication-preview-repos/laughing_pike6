import { Module } from "@nestjs/common";
import { FieldModelModuleBase } from "./base/fieldModel.module.base";
import { FieldModelService } from "./fieldModel.service";
import { FieldModelController } from "./fieldModel.controller";
import { FieldModelResolver } from "./fieldModel.resolver";

@Module({
  imports: [FieldModelModuleBase],
  controllers: [FieldModelController],
  providers: [FieldModelService, FieldModelResolver],
  exports: [FieldModelService],
})
export class FieldModelModule {}
