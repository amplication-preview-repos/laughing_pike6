/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { ArgsType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { FieldModelCreateInput } from "./FieldModelCreateInput";
import { ValidateNested } from "class-validator";
import { Type } from "class-transformer";

@ArgsType()
class CreateFieldModelArgs {
  @ApiProperty({
    required: true,
    type: () => FieldModelCreateInput,
  })
  @ValidateNested()
  @Type(() => FieldModelCreateInput)
  @Field(() => FieldModelCreateInput, { nullable: false })
  data!: FieldModelCreateInput;
}

export { CreateFieldModelArgs as CreateFieldModelArgs };