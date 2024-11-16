import * as graphql from "@nestjs/graphql";
import { PasswordRecoveryLogResolverBase } from "./base/passwordRecoveryLog.resolver.base";
import { PasswordRecoveryLog } from "./base/PasswordRecoveryLog";
import { PasswordRecoveryLogService } from "./passwordRecoveryLog.service";

@graphql.Resolver(() => PasswordRecoveryLog)
export class PasswordRecoveryLogResolver extends PasswordRecoveryLogResolverBase {
  constructor(protected readonly service: PasswordRecoveryLogService) {
    super(service);
  }
}
