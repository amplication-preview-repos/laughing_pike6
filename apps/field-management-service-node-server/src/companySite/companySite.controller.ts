import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { CompanySiteService } from "./companySite.service";
import { CompanySiteControllerBase } from "./base/companySite.controller.base";

@swagger.ApiTags("companySites")
@common.Controller("companySites")
export class CompanySiteController extends CompanySiteControllerBase {
  constructor(protected readonly service: CompanySiteService) {
    super(service);
  }
}
