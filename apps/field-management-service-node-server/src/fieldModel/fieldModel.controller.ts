import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { FieldModelService } from "./fieldModel.service";
import { FieldModelControllerBase } from "./base/fieldModel.controller.base";

@swagger.ApiTags("fieldModels")
@common.Controller("fieldModels")
export class FieldModelController extends FieldModelControllerBase {
  constructor(protected readonly service: FieldModelService) {
    super(service);
  }
}
