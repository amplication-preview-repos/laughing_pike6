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
import { CompanySiteWhereInput } from "./CompanySiteWhereInput";
import { IsOptional, ValidateNested, IsInt } from "class-validator";
import { Type } from "class-transformer";
import { CompanySiteOrderByInput } from "./CompanySiteOrderByInput";

@ArgsType()
class CompanySiteFindManyArgs {
  @ApiProperty({
    required: false,
    type: () => CompanySiteWhereInput,
  })
  @IsOptional()
  @ValidateNested()
  @Field(() => CompanySiteWhereInput, { nullable: true })
  @Type(() => CompanySiteWhereInput)
  where?: CompanySiteWhereInput;

  @ApiProperty({
    required: false,
    type: [CompanySiteOrderByInput],
  })
  @IsOptional()
  @ValidateNested({ each: true })
  @Field(() => [CompanySiteOrderByInput], { nullable: true })
  @Type(() => CompanySiteOrderByInput)
  orderBy?: Array<CompanySiteOrderByInput>;

  @ApiProperty({
    required: false,
    type: Number,
  })
  @IsOptional()
  @IsInt()
  @Field(() => Number, { nullable: true })
  @Type(() => Number)
  skip?: number;

  @ApiProperty({
    required: false,
    type: Number,
  })
  @IsOptional()
  @IsInt()
  @Field(() => Number, { nullable: true })
  @Type(() => Number)
  take?: number;
}

export { CompanySiteFindManyArgs as CompanySiteFindManyArgs };