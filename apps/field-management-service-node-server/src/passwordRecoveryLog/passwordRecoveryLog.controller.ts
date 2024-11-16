import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { PasswordRecoveryLogService } from "./passwordRecoveryLog.service";
import { PasswordRecoveryLogControllerBase } from "./base/passwordRecoveryLog.controller.base";

@swagger.ApiTags("passwordRecoveryLogs")
@common.Controller("passwordRecoveryLogs")
export class PasswordRecoveryLogController extends PasswordRecoveryLogControllerBase {
  constructor(protected readonly service: PasswordRecoveryLogService) {
    super(service);
  }
}
